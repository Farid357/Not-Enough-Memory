using System;

namespace NotEnoughMemory.Model
{
    public sealed class Random : IRandom
    {
        public bool TryGetLuckyNumberFrom(IChance chance)
        {
            if (chance == null) 
                throw new ArgumentNullException(nameof(chance));

            return chance.TryGetLucky();
        }
    }
}