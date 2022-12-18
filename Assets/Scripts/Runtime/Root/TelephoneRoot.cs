using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class TelephoneRoot : Root
    {
        [SerializeField] private ITelephoneView _telephoneView;
        [SerializeField] private IMemoryView _memoryView;
        [SerializeField] private Button _telephone;
        [SerializeField] private TelephoneClickEffect _telephoneClickEffect;
        
        public override void Compose()
        {
            var memory = new Memory(_memoryView, _telephoneView);
            _telephone.Init();
            _telephone.Add(_telephoneClickEffect.Play).Add(() => memory.Fill(1));
        }
    }
}