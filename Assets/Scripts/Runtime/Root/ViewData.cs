using NotEnoughMemory.Model;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class ViewData : MonoBehaviour
    {
        [SerializeField] private TelephoneView _telephoneView;
        [SerializeField] private MemoryView _memoryView;
        [SerializeField] private TelephoneClickEffect _telephoneClickEffect;

        public ITelephoneClickEffect TelephoneClickEffect => _telephoneClickEffect;
        
        public ITelephoneView TelephoneView => _telephoneView;

        public IMemoryView MemoryView => _memoryView;
    }
}