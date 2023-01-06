using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Factories;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public sealed class Game : IGame
    {
        public Game(IUnity unity, IGameLoop loop)
        {
            Loop = loop ?? throw new ArgumentNullException(nameof(loop));
            IUI ui = unity.UI;
            IAudios audio = unity.Views.Audios;
            IScenes scenes = unity.Scenes;
            ISaveStorages saveStorages = new SaveStorages(loop);
            IFactory<IWallet> walletFactory = new WalletFactory(new TextView(ui.Texts.Money), saveStorages);
            IWallet wallet = walletFactory.Create();
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(loop, unity, wallet);
            ITelephone telephone = telephoneFactory.Create();
            ISettingsFactory settingsFactory = new SettingsFactory(ui.UnityButtons, saveStorages, new Music(audio.Music));
            settingsFactory.Create();
            IInputsFactory inputsFactory = new InputsFactory(ui.Windows, loop.GameUpdate, Time);
            IGameUIFactory gameUIRoot = new GameUIFactory(unity, Time);
            gameUIRoot.Create();
            inputsFactory.Create();
        }

        public IGameTime Time { get; } = new GameTime();

        public IGameLoop Loop { get; }
    }
}