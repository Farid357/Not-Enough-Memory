using System;
using NotEnoughMemory.Game;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class MenuUIFactory : IMenuUIFactory
    {
        private readonly IGameEngine _gameEngine;

        public MenuUIFactory(IGameEngine gameEngine)
        {
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
        }

        public void Create()
        {
            IUI ui = _gameEngine.UI;
            IGameEngineButtons gameEngineButtons = ui.GameEngineButtons;
            IButton playButton = new SceneLoadButton(_gameEngine.SceneLoader, _gameEngine.Scenes.Game);
            gameEngineButtons.Play.Init(playButton);
            IButton exitButton = new ExitGameButton();
            gameEngineButtons.Exit.Init(exitButton);
        }
    }
}