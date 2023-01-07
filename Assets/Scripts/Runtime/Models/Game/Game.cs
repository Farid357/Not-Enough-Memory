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
        public Game(IUnity unity)
        {
            IUI ui = unity.UI;
            IAudios audio = unity.Views.Audios;
            ISaveStorages saveStorages = new SaveStorages(Loop);
            IFactory<IWallet> walletFactory = new WalletFactory(new TextView(ui.Texts.Money), saveStorages);
            IWallet wallet = walletFactory.Create();
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(Loop, unity, wallet);
            ITelephone telephone = telephoneFactory.Create();
            ISettingsFactory settingsFactory = new SettingsFactory(ui.UnityButtons, saveStorages, new Music(audio.Music));
            settingsFactory.Create();
            IInputsFactory inputsFactory = new InputsFactory(ui.Windows, Loop.GameUpdate, Time);
            IGameUIFactory gameUIFactory = new GameUIFactory(unity, Time);
            gameUIFactory.Create();
            inputsFactory.Create();
        }

        public IGameTime Time { get; } = new GameTime();

        public IGameLoop Loop { get; } = new GameLoop();
    }
}