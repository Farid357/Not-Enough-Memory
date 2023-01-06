using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.View
{
    public sealed class Views : MonoBehaviour, IViews
    {
        [SerializeField] private TelephoneView _telephoneView;
        [SerializeField] private MemoryView _memoryView;
        [SerializeField] private TelephonePressEffect _telephonePressEffect;
        [SerializeField] private Effects _effects;
        [SerializeField] private Audios _audios;

        public IEffects Effects => _effects;

        public IAudios Audios => _audios;
        
        public ITelephoneView Telephone => _telephoneView;

        public IMemoryView Memory => _memoryView;
      
    }
}