using System;

namespace NotEnoughMemory.Audio
{
    public sealed class Sound : IAudio
    {
        private readonly IUnityAudio _audio;

        public Sound(IUnityAudio audio)
        {
            _audio = audio ?? throw new ArgumentNullException(nameof(audio));
        }

        public bool IsPlaying => _audio.IsPlaying;

        public void Play()
        {
            if (IsPlaying)
                throw new InvalidOperationException("The sound is already playing, you can't play it!");
            
            _audio.PlayOneShot();
        }

        public void Stop()
        {
            if (IsPlaying == false)
                throw new InvalidOperationException("The sound is not playing, you can't stop it!");
            
            _audio.Stop();
        }
    }
}