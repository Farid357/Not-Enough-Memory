using System;
using NotEnoughMemory.Audio;

namespace NotEnoughMemory.UI
{
    public sealed class AudioPlayButton : IButton
    {
        private readonly IAudio _audio;

        public AudioPlayButton(IAudio audio)
        {
            _audio = audio ?? throw new ArgumentNullException(nameof(audio));
        }

        public void Press()
        {
            var audioIsNotPlaying = _audio.IsPlaying == false;
            
            if (audioIsNotPlaying)
                _audio.Play();
        }
    }
}