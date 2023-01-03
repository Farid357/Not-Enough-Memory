using System;

namespace NotEnoughMemory.Model
{
    public sealed class Telephone : ITelephone
    {
        private readonly ITelephoneView _telephoneView;
        private readonly IMemoryView _memoryView;

        public Telephone(ITelephoneView telephoneView, IMemory memory, IMemoryView memoryView)
        {
            _telephoneView = telephoneView ?? throw new ArgumentNullException(nameof(telephoneView));
            Memory = memory ?? throw new ArgumentNullException(nameof(memory));
            _memoryView = memoryView ?? throw new ArgumentNullException(nameof(memoryView));
        }
        
        public IMemory Memory { get; }
        
        public bool IsBroken { get; private set; }

        public void Update(float deltaTime)
        {
            var memoryFillingAmount = Memory.Amount;
            var maxMemoryFillingAmount = _telephoneView.Data.NeedMemoryFillingAmount;
            _memoryView.Visualize(maxMemoryFillingAmount, Memory.Amount);

            if (_telephoneView.ReadyToSwitchAppearance(memoryFillingAmount))
            {
                _telephoneView.SwitchAppearance(memoryFillingAmount);
                Memory.Clear();
            }
        }
        
        public void Break()
        {
            if (IsBroken)
                throw new InvalidOperationException("Telephone is already broken!");
            
            Memory.Break();
            _telephoneView.SwitchAppearanceToBroken();
            IsBroken = true;
        }

        public void Fix()
        {
            if (!IsBroken)
                throw new InvalidOperationException("Telephone is already fixed!");
            
            Memory.Fix();
            _telephoneView.SwitchAppearanceToFixed();
            IsBroken = false;
        }
    }
}