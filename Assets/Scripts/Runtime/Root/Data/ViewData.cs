using NotEnoughMemory.Model;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class ViewData : MonoBehaviour
    {
        [SerializeField] private TelephoneView _telephoneView;
        [SerializeField] private MemoryView _memoryView;
        [SerializeField] private TelephoneClickEffect _telephoneClickEffect;
        [SerializeField] private ButtonsData _buttonsData;
        
        public ITelephoneClickEffect TelephoneClickEffect => _telephoneClickEffect;
        
        public ITelephoneView TelephoneView => _telephoneView;

        public IMemoryView MemoryView => _memoryView;
        
        public IButtonsData Buttons => _buttonsData;
    }
}