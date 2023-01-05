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
    
    public sealed class UnityAudioWithRandomPlayingClip : MonoBehaviour, IUnityAudio
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip[] _clips;

        public bool IsPlaying => _audioSource.isPlaying;
        
        public void Play()
        {
       
        }

        public void Stop()
        {
    
        }

        public void PlayOneShot()
        {
        }
    }
}