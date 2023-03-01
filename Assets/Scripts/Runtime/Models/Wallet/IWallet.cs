﻿namespace NotEnoughMemory.Model
{
    public interface IWallet
    {
        Money Money { get; }

        void Take(Money money);

        void Put(Money money);
    }
}