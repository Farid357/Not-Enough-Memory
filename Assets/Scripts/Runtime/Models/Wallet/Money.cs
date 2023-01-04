﻿using System;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.Model
{
    [Serializable]
    public sealed class Money
    {
        public Money(int amount)
        {
            Amount = amount.TryThrowLessThanOrEqualsToZeroException();
        }
        
        public int Amount { get; }
        
        public static Money operator -(Money moneyA, Money moneyB)
        {
            return new Money(moneyA.Amount - moneyB.Amount);
        }
        
        public static Money operator +(Money moneyA, Money moneyB)
        {
            return new Money(moneyA.Amount + moneyB.Amount);
        }

        public static implicit operator int(Money money) => money.Amount;
        
    }
}