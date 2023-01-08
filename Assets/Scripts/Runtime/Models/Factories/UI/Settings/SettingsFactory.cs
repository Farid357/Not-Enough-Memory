using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class UISettingsFactory : IUISettingsFactory
    {
        private readonly IUI _ui;
        private readonly ISaveStorages _saveStorages;
        private readonly IAudio _music;

        public UISettingsFactory(IUI ui, ISaveStorages saveStorages, IAudio music)
        {
            _ui = ui ?? throw new ArgumentNullException(nameof(ui));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _music = music ?? throw new ArgumentNullException(nameof(music));
        }

        public void Create()
        {
            IGameEngineButtons buttons = _ui.GameEngineButtons;
            IButton deleteAllSavesButton = new DeleteAllSavesButton(_saveStorages);
            IButton musicButton = new MusicButton(_music);
            IDropdownFactory qualityDropdownFactory = new QualityDropdownFactory(_ui);
            qualityDropdownFactory.Create();
            buttons.DeleteAllSaves.Init(deleteAllSavesButton);
            buttons.Music.Init(musicButton);
        }
    }
}