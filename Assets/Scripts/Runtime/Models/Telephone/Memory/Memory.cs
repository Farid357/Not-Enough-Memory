using System;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.Model
{
    public sealed class Memory : IMemory
    {
        public bool IsBroken { get; private set; }
        
        public bool HasAmountChanged { get; private set; }
        
        public int Amount { get; private set; }

        public void Fill(int amount)
        {
            if (IsBroken)
                throw new InvalidOperationException("Memory is broken, you can't fill it!");
            
            Amount += amount.TryThrowLessThanOrEqualsToZeroException();
            HasAmountChanged = true;
        }

        public void Clear() => Clear(Amount);

        public void Break()
        {
            if (IsBroken)
                throw new InvalidOperationException("Memory is already broken!");
            
            IsBroken = true;
        }

        public void Fix()
        {
            if (!IsBroken)
                throw new InvalidOperationException("Memory is already fixed!");
            
            IsBroken = false;
        }
        
        public bool CanClear(int amount) => Amount - amount >= 0;

        public void Clear(int amount)
        {
            if (CanClear(amount) == false)
                throw new InvalidOperationException("Can't clear amount!");

            Amount -= amount.TryThrowLessThanOrEqualsToZeroException();
            HasAmountChanged = true;
        }

        public void LateUpdate()
        {
            HasAmountChanged = false;
        }
    }
}