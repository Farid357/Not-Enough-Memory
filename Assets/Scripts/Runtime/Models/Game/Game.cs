using NotEnoughMemory.Audio;
using NotEnoughMemory.Factories;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Menu;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public sealed class Game : IGame
    {
        public Game(IGameEngine engine)
        {
            IMenu menu = new Menu.Menu(engine);
            IUI ui = engine.UI;
            IAudios audio = engine.Views.Audios;
            ISaveStorages saveStorages = new SaveStorages(Loop);
            IFactory<IWallet> walletFactory = new WalletFactory(new TextView(ui.Texts.Money), saveStorages);
            IWallet wallet = walletFactory.Create();
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(Loop, engine, wallet);
            ITelephone telephone = telephoneFactory.Create();
            ISettingsFactory settingsFactory = new SettingsFactory(ui.GameEngineButtons, saveStorages, new Music(audio.Music));
            settingsFactory.Create();
            IInputsFactory inputsFactory = new InputsFactory(ui.Windows, Loop.GameUpdate);
            IGameUIFactory uiFactory = new GameUIFactory(engine, Time);
            uiFactory.Create();
            inputsFactory.Create();
        }

        public IGameTime Time { get; } = new GameTime();

        public IGameLoop Loop { get; } = new GameLoop();
    }
}