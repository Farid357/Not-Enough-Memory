using System;
using NotEnoughMemory.Game;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    //Need Refactoring
    public sealed class GameUIFactory : IGameUIFactory
    {
        private readonly IGameEngine _gameEngine;
        private readonly IGameTime _gameTime;

        public GameUIFactory(IGameEngine gameEngine, IGameTime gameTime)
        {
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Create()
        {
            IUI ui = _gameEngine.UI;
            ui.GameEngineButtons.Exit.Init(new SceneLoadButton(_gameEngine.SceneLoader, _gameEngine.Scenes.Menu));
            ui.GameEngineButtons.CloseExitWindow.Init(new CloseWindowButton(_gameTime, ui.Windows.Exit));
            IDropdownFactory qualityDropdownFactory = new QualityDropdownFactory(ui);
            qualityDropdownFactory.Create();
        }
    }
}