using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Game;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Factories
{
    public sealed class GameUIFactory : IGameUIFactory
    {
        private readonly IGameEngine _gameEngine;
        private readonly ISaveStorages _saveStorages;
        private readonly IGameUpdate _gameUpdate;

        public GameUIFactory(IGameEngine gameEngine, ISaveStorages saveStorages, IGameUpdate gameUpdate)
        {
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _gameUpdate = gameUpdate ?? throw new ArgumentNullException(nameof(gameUpdate));
        }

        public void Create()
        {
            IUI ui = _gameEngine.UI;
            IViews views = _gameEngine.Views;
            IWindows windows = ui.Windows;
            IButton exit = new Buttons(new OpenWindowButton(windows.Menu), new CloseWindowButton(windows.Game));
            ui.GameEngineButtons.ExitGame.Init(exit);
            ui.GameEngineButtons.CloseExitWindow.Init(new CloseWindowButton(windows.Exit));
            IAudio music = new Music(views.Audios.Music);
            IUISettingsFactory uiSettingsFactory = new UISettingsFactory(_gameEngine.UI, _saveStorages, music);
            ITelephoneScrollViewFactory telephoneScrollViewFactory = new TelephoneScrollViewFactory(_gameUpdate, views.Telephone,
                    views.Factories.TelephoneScrollItemsFactory);

            ITelephonesScrollView telephonesScrollView = telephoneScrollViewFactory.Create();
            telephonesScrollView.Enable();
            uiSettingsFactory.Create();
        }
    }
}