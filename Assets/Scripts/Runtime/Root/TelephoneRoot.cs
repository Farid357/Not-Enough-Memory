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
        private readonly ILateSystemUpdate _lateSystemUpdate = new LateSystemUpdate();
        private readonly Memory _memory = new();

        public override void Compose()
        {
            var telephone = new Telephone(_telephoneView, _memory, _memoryView);
            _telephoneButton.Init();
            _telephoneClickEffect.Init(_telephoneView);
            var telephoneCLickAction = new TelephoneClickAction(telephone, _telephoneClickEffect);
            _telephoneButton.Add(telephoneCLickAction);
            _systemUpdate.Add(telephone);
            _lateSystemUpdate.Add(_memory);
        }

        private void Update()
        {
            _systemUpdate.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            _lateSystemUpdate.LateUpdate(Time.deltaTime);
        }
    }
}