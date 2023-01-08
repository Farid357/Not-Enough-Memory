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
        private readonly IGameUIFactory _uiFactory;
        private readonly IInputsFactory _inputsFactory;
        private readonly IMenu _menu;

        public Game(IGameEngine engine)
        {
            _menu = new Menu.Menu(engine);
            IUI ui = engine.UI;
            ISaveStorages saveStorages = new SaveStorages();
            IFactory<IWallet> walletFactory = new WalletFactory(new TextView(ui.Texts.Money), saveStorages);
            IWallet wallet = walletFactory.Create();
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(Loop, engine, wallet);
            ITelephone telephone = telephoneFactory.Create();
            _inputsFactory = new InputsFactory(ui.Windows, Loop.GameUpdate);
            _uiFactory = new GameUIFactory(engine, saveStorages);
            engine.Loop.Add(Loop, Time);
        }

        public IGameTime Time { get; } = new GameTime();

        public IGameLoop Loop { get; } = new GameLoop();
        
        public void Play()
        {
            _menu.Open();
            _uiFactory.Create();
            _inputsFactory.Create();
        }
    }
}