using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.View
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