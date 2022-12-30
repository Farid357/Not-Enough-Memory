using System;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.UI
{
    public sealed class TelephoneClickAction : IButtonClickAction
    {
        private readonly IMemoryBreaker _memoryBreaker;
        private readonly IMemory _memory;
        private readonly ITelephoneClickEffect _telephoneClickEffect;

        public TelephoneClickAction(IMemory memory, ITelephoneClickEffect telephoneClickEffect)
        {
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _telephoneClickEffect = telephoneClickEffect ?? throw new ArgumentNullException(nameof(telephoneClickEffect));
            _memoryBreaker = new MemoryBreaker();
        }

        public void OnClick()
        {
            _telephoneClickEffect.Play();
            
            if (_memory.IsBroken)
            {
                if (_memory.CanClear(1))
                    _memory.Clear(1);
            }
            
            else
            {
                _memory.Fill(1);
                _memoryBreaker.TryBreak(_memory);
            }
        }
    }
}