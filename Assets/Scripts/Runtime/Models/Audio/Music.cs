using System;
using UnityEngine;

namespace NotEnoughMemory.Audio
{
    public sealed class Music : IAudio
    {
        private readonly IUnityAudio _audio;

        public Music(IUnityAudio audio)
        {
            _audio = audio ?? throw new ArgumentNullException(nameof(audio));
        }

        public bool IsPlaying => _audio.IsPlaying;

        public void Play()
        {
            if (IsPlaying)
                throw new InvalidOperationException("The music is already playing, you can't play it!");
            
            _audio.Play();
        }

        public void Stop()
        {
            if (IsPlaying == false)
                throw new InvalidOperationException("The music is not playing, you can't stop it!");
            
            _audio.Stop();
        }
    }
}