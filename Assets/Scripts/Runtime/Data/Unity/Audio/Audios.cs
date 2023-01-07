using UnityEngine;

namespace NotEnoughMemory.Audio
{
    public sealed class Audios : MonoBehaviour, IAudios
    {
        [SerializeField] private UnityAudio _music;
        [SerializeField] private UnityAudioWithRandomPlayingClip _telephonePress;

        public IGameEngineAudio Music => _music;

        public IGameEngineAudio TelephonePress => _telephonePress;
    }
}