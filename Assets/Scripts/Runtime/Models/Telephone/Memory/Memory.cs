﻿using System;
using NotEnoughMemory.Model.Tools;

namespace NotEnoughMemory.Model
{
    public sealed class Memory : IMemory
    {
        public bool IsBroken { get; private set; }
        
        public int Amount { get; private set; }

        public void Fill(int amount)
        {
            if (IsBroken)
                throw new InvalidOperationException("Memory is broken, you can't fill it!");
            
            Amount += amount.ThrowIfLessThanOrEqualsToZeroException();
        }

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

            Amount -= amount.ThrowIfLessThanOrEqualsToZeroException();
        }
    }
}