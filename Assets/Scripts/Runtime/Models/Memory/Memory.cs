using System;
using NotEnoughtMemory.Model.Tools.Utils;

namespace NotEnoughMemory.Model
{
    public sealed class Memory : IMemory
    {
        private readonly IMemoryView _memoryView;
        private readonly ITelephoneView _telephoneView;

        public Memory(IMemoryView memoryView, ITelephoneView telephoneView)
        {
            _memoryView = memoryView ?? throw new ArgumentNullException(nameof(memoryView));
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
        }

        public int Amount { get; private set; }

        public void Fill(int amount)
        {
            Amount += amount.TryThrowLessThanOrEqualsToZeroException();
            _memoryView.Visualize(_telephoneView.Data.NeedMemoryFillingAmount, Amount);

            if (_telephoneView.ReadyToSwitchAppearance(Amount))
            {
                _telephoneView.SwitchAppearance(Amount);
                Clear();
            }
        }

        private void Clear()
        {
            Amount = 0;
            _memoryView.Visualize(_telephoneView.Data.NeedMemoryFillingAmount, Amount);
        }
    }
}