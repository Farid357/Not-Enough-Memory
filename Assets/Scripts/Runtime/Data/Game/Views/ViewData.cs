using NotEnoughMemory.Model;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class ViewData : MonoBehaviour, IViewData
    {
        [SerializeField] private TelephoneView _telephoneView;
        [SerializeField] private MemoryView _memoryView;
        [SerializeField] private TelephonePressEffect _telephonePressEffect;
        
        public ITelephonePressEffect TelephonePressEffect => _telephonePressEffect;
        
        public ITelephoneView Telephone => _telephoneView;

        public IMemoryView Memory => _memoryView;
      
    }
}