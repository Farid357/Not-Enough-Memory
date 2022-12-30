using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.Root
{
    public sealed class TelephoneRoot : Root
    {
        [SerializeField] private TelephoneView _telephoneView;
        [SerializeField] private MemoryView _memoryView;
        [SerializeField] private Button _telephoneButton;
        [SerializeField] private TelephoneClickEffect _telephoneClickEffect;
        private readonly ISystemUpdate _systemUpdate = new SystemUpdate();
        private readonly ILateUpdateable _lateSystemUpdate = new LateSystemUpdate();
        
        public override void Compose()
        {
            var memory = new Memory();
            var telephone = new Telephone(_telephoneView, memory, _memoryView);
            _telephoneButton.Init();
            _telephoneClickEffect.Init(_telephoneView);
            _telephoneButton.Add(_telephoneClickEffect.Play).Add(() => memory.Fill(1));
            _systemUpdate.Add(telephone);
        }

        private void Update()
        {
            _systemUpdate.Update(Time.deltaTime);
        }
    }
}