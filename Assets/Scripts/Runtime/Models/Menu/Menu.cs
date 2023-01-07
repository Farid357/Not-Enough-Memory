using NotEnoughMemory.Factories;
using NotEnoughMemory.Game;

namespace NotEnoughMemory.Menu
{
    public sealed class Menu : IMenu
    {
        public Menu(IGameEngine gameEngine)
        {
            IMenuUIFactory uiFactory = new MenuUIFactory(gameEngine);
            uiFactory.Create();
        }
    }
}