using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Game;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class GameUIFactory : IGameUIFactory
    {
        private readonly IGameEngine _gameEngine;
        private readonly ISaveStorages _saveStorages;

        public GameUIFactory(IGameEngine gameEngine, ISaveStorages saveStorages)
        {
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public void Create()
        {
            IUI ui = _gameEngine.UI;
            IWindows windows = ui.Windows;
            IButton exit = new Buttons(new IButton[] { new OpenWindowButton(windows.Menu), new CloseWindowButton(windows.Game) });
            ui.GameEngineButtons.ExitGame.Init(exit);
            ui.GameEngineButtons.CloseExitWindow.Init(new CloseWindowButton(windows.Exit));
            IAudio music = new Music(_gameEngine.Views.Audios.Music);
            IUISettingsFactory uiSettingsFactory = new UISettingsFactory(_gameEngine.UI, _saveStorages, music);
            uiSettingsFactory.Create();
        }
    }
}