using UnityEngine;

namespace NotEnoughMemory.Audio
{
    public sealed class Audios : MonoBehaviour, IAudios
    {
        [SerializeField] private UnityAudio _music;
        [SerializeField] private UnityAudioWithRandomPlayingClip _telephonePress;

        public IUnityAudio Music => _music;

        public IUnityAudio TelephonePress => _telephonePress;
    }
}