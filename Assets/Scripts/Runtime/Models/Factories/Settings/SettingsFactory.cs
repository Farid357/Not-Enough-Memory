using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class SettingsFactory : ISettingsFactory
    {
        private readonly IGameEngineButtons _buttons;
        private readonly ISaveStorages _saveStorages;
        private readonly IAudio _music;

        public SettingsFactory(IGameEngineButtons buttons, ISaveStorages saveStorages, IAudio music)
        {
            _buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _music = music ?? throw new ArgumentNullException(nameof(music));
        }

        public void Create()
        {
            IButton deleteAllSavesButton = new DeleteAllSavesButton(_saveStorages);
            IButton musicButton = new MusicButton(_music);
            _buttons.DeleteAllSaves.Init(deleteAllSavesButton);
            _buttons.Music.Init(musicButton);
        }
    }
}