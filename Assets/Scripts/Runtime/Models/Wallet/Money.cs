using System;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.Model
{
    [Serializable]
    public sealed class Money
    {
        public Money(int value)
        {
            Value = value.TryThrowLessThanOrEqualsToZeroException();
        }
        
        public int Value { get; }
        
        public static Money operator -(Money moneyA, Money moneyB)
        {
            return new Money(moneyA.Value - moneyB.Value);
        }
        
        public static Money operator +(Money moneyA, Money moneyB)
        {
            return new Money(moneyA.Value + moneyB.Value);
        }

        public static implicit operator int(Money money) => money.Value;
        
        public override bool Equals(object obj)
        {
            var money = (Money)obj;
            return Value == money.Value;
        }
    }
}