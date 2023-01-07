using System;
using NotEnoughMemory.Game;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    //Need Refactoring
    public sealed class GameUIFactory : IGameUIFactory
    {
        private readonly IUnity _unity;
        private readonly IGameTime _gameTime;

        public GameUIFactory(IUnity unity, IGameTime gameTime)
        {
            _unity = unity ?? throw new ArgumentNullException(nameof(unity));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Create()
        {
            IUI ui = _unity.UI;
            ui.UnityButtons.Exit.Init(new SceneLoadButton(_unity.SceneLoader, _unity.Scenes.Menu));
            ui.UnityButtons.CloseExitWindow.Init(new CloseWindowButton(_gameTime, ui.Windows.Exit));
            new QualityDropdownFactory(ui).Create();
        }
    }
}