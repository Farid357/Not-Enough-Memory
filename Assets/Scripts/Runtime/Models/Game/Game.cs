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
        private readonly IGameLoop _loop;

        public Game(IGameEngine engine)
        {
            IGameTime time = new GameTime();
            _loop = new GameLoop(time);
            _menu = new Menu.Menu(engine);
            IUI ui = engine.UI;
            ISaveStorages saveStorages = new SaveStorages();
            IFactory<IWallet> walletFactory = new WalletFactory(new TextView(ui.Texts.Money), saveStorages);
            IWallet wallet = walletFactory.Create();
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(engine, wallet);
            ITelephone telephone = telephoneFactory.Create();
            _inputsFactory = new InputsFactory(ui.Windows, _loop.Objects);
            _uiFactory = new GameUIFactory(engine, saveStorages, _loop.Objects);
        }
        
        public void Play()
        {
            _menu.Open();
            _uiFactory.Create();
            _inputsFactory.Create();
            _loop.Start();
        }
    }
}