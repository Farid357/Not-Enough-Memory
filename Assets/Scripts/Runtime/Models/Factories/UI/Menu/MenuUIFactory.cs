using System;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class MenuUIFactory : IMenuUIFactory
    {
        private readonly IUI _ui;

        public MenuUIFactory(IUI ui)
        {
            _ui = ui ?? throw new ArgumentNullException(nameof(ui));
        }

        public void Create()
        {
            IGameEngineButtons gameEngineButtons = _ui.GameEngineButtons;
            IButton playButton =  new Buttons(new IButton[]{new CloseWindowButton(_ui.Windows.Menu), new OpenWindowButton(_ui.Windows.Game)});
            gameEngineButtons.Play.Init(playButton);
            IButton exitButton = new ExitGameButton();
            gameEngineButtons.ExitGame.Init(exitButton);
        }
    }
}