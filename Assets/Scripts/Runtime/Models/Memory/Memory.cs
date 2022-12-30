using System;
using NotEnoughMemory.GameLoop;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.Model
{
    public sealed class Memory : IMemory, ILateUpdateable
    {
        public bool HasAmountChanged { get; private set; }
        
        public int Amount { get; private set; }

        public void Fill(int amount)
        {
            Amount += amount.TryThrowLessThanOrEqualsToZeroException();
            HasAmountChanged = true;
        }

        public void Clear()
        {
            if (Amount == 0)
                throw new InvalidOperationException("Has already cleaned!");
            
            Amount = 0;
            HasAmountChanged = true;
        }

        public void LateUpdate(float deltaTime)
        {
            HasAmountChanged = false;
        }
    }
}