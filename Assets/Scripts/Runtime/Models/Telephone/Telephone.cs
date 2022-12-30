using System;
using NotEnoughMemory.GameLoop;

namespace NotEnoughMemory.Model
{
    public sealed class Telephone : IUpdateable
    {
        private readonly ITelephoneView _telephoneView;
        private readonly IMemory _memory;
        private readonly IMemoryView _memoryView;

        public Telephone(ITelephoneView telephoneView, IMemory memory, IMemoryView memoryView)
        {
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
            _memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _memoryView = memoryView ?? throw new ArgumentNullException(nameof(memoryView));
        }

        public void Update(float deltaTime)
        {
            var memoryFillingAmount = _memory.Amount;
            var maxMemoryFillingAmount = _telephoneView.Data.NeedMemoryFillingAmount;
            _memoryView.Visualize(maxMemoryFillingAmount, _memory.Amount);

            if (_telephoneView.ReadyToSwitchAppearance(memoryFillingAmount))
            {
                _telephoneView.SwitchAppearance(memoryFillingAmount);
                _memory.Clear();
            }
        }
    }
}