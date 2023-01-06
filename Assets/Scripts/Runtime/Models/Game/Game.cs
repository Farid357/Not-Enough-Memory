using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Factories;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.SceneLoading;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public sealed class Game : IGame
    {
        private readonly IGameTime _time = new GameTime();

        public Game(IGameData data, IGameLoop gameLoop, ISceneLoader sceneLoader)
        {
            IUIData ui = data.UI;
            IAudioData audio = data.Audio;
            IScenesData scenes = data.Scenes;
            ISaveStorages saveStorages = new SaveStorages(gameLoop);
            IFactory<IWallet> walletFactory = new WalletFactory(new TextView(ui.Texts.Money), saveStorages);
            IWallet wallet = walletFactory.Create();
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(gameLoop, data, wallet);
            ITelephone telephone = telephoneFactory.Create();
            ISettingsFactory settingsFactory = new SettingsFactory(ui.UnityButtons, saveStorages, new Music(audio.Music));
            settingsFactory.Create();
            IInputFactories inputFactories = new InputFactories(ui.Windows, gameLoop.GameUpdate);
            IGameUIFactory gameUIRoot = new GameUIFactory(ui, scenes, sceneLoader);
            gameUIRoot.Create();
            inputFactories.CreateOpenExitWindowInput();
        }

        public bool IsPaused => _time.IsActive;
        
        public bool IsNotPaused => !_time.IsActive;

        public void Pause()
        {
            if (IsPaused)
                throw new InvalidOperationException("Game is already paused!");

            _time.Stop();
        }

        public void Continue()
        {
            if (IsPaused == false)
                throw new InvalidOperationException("Game is not paused!");

            _time.Enable();
        }
    }
}