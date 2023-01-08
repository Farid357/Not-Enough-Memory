using System;
using NotEnoughMemory.Factories;
using NotEnoughMemory.Game;

namespace NotEnoughMemory.Menu
{
    public sealed class Menu : IMenu
    {
        private readonly IGameEngine _gameEngine;

        public Menu(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
        }

        public void Open()
        {
            IMenuUIFactory uiFactory = new MenuUIFactory(_gameEngine.UI);
            uiFactory.Create();
        }
    }
}