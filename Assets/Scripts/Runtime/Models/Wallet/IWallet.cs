﻿using NotEnoughMemory.Game.Loop;

namespace NotEnoughMemory.Model
{
    public interface IWallet : ILateUpdateable
    {
        Money Money { get; }
        
        bool HasMoneyChanged { get; }

        void Take(Money money);

        void Put(Money money);
    }
}