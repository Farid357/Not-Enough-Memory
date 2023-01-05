﻿using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Storage;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Root
{
    public sealed class SettingsRoot : IRoot
    {
        private readonly IUnityButtonsData _buttons;
        private readonly ISaveStorages _saveStorages;
        private readonly IAudio _music;

        public SettingsRoot(IUnityButtonsData buttons, ISaveStorages saveStorages, IAudio music)
        {
            _buttons = buttons ?? throw new ArgumentNullException(nameof(buttons));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
            _music = music ?? throw new ArgumentNullException(nameof(music));
        }

        public void Compose()
        {
            IButton deleteAllSavesButton = new DeleteAllSavesButton(_saveStorages);
            IButton musicButton = new MusicButton(_music);
            _buttons.DeleteAllSaves.Init(deleteAllSavesButton);
            _buttons.Music.Init(musicButton);
        }
    }
}