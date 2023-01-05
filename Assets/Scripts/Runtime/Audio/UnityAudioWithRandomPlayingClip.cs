using UnityEngine;

namespace NotEnoughMemory.Audio
{
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
            var randomClip = _clips[Random.Range(0, _clips.Length)];
            _audioSource.PlayOneShot(randomClip);
        }
    }
}