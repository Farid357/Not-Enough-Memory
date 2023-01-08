using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Game;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    //Need Refactoring
    public sealed class GameUIFactory : IGameUIFactory
    {
        private readonly IGameEngine _gameEngine;
        private readonly IGameTime _gameTime;
        private readonly ISaveStorages _saveStorages;

        public GameUIFactory(IGameEngine gameEngine, IGameTime gameTime, ISaveStorages saveStorages)
        {
            _gameEngine = gameEngine ?? throw new ArgumentNullException(nameof(gameEngine));
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public void Create()
        {
            IUI ui = _gameEngine.UI;
            ui.GameEngineButtons.Exit.Init(new SceneLoadButton(_gameEngine.SceneLoader, _gameEngine.Scenes.Menu));
            ui.GameEngineButtons.CloseExitWindow.Init(new CloseWindowButton(_gameTime, ui.Windows.Exit));
            IDropdownFactory qualityDropdownFactory = new QualityDropdownFactory(ui);
            qualityDropdownFactory.Create();
            new UISettingsFactory(_gameEngine.UI.GameEngineButtons, _saveStorages, new Music(_gameEngine.Views.Audios.Music));
        }
    }
}