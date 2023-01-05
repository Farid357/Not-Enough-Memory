using System;
using NotEnoughMemory.Audio;

namespace NotEnoughMemory.UI
{
    public sealed class MusicButton : IButton
    {
        private readonly IAudio _music;

        public MusicButton(IAudio music)
        {
            _music = music ?? throw new ArgumentNullException(nameof(music));
        }

        public void Press()
        {
            if (_music.IsPlaying)
            {
                _music.Stop();
            }

            else
            {
                _music.Play();
            }
        }
    }
}