using System;
using NotEnoughMemory.Audio;

namespace NotEnoughMemory.UI
{
    public sealed class TelephonePressAudioPlayButton : IButton
    {
        private readonly IAudio _audio;

        public TelephonePressAudioPlayButton(IAudio audio)
        {
            _audio = audio ?? throw new ArgumentNullException(nameof(audio));
        }

        public void Press()
        {
            if (_audio.IsPlaying == false)
                _audio.Play();
        }
    }
}