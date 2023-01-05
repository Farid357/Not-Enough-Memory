using UnityEngine;

namespace NotEnoughMemory.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class UnityAudio : MonoBehaviour, IUnityAudio
    {
        private AudioSource _audioSource;

        public bool IsPlaying => _audioSource.isPlaying;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            _audioSource.Play();
        }

        public void Stop()
        {
            _audioSource.Stop();
        }


        public void PlayOneShot()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}