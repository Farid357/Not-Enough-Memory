using System;

namespace NotEnoughMemory.Model
{
    public sealed class Random : IRandom
    {
        private readonly IChance _chance;

        public Random(IChance chance)
        {
            _chance = chance ?? throw new ArgumentNullException(nameof(chance));
        }

        public bool TryLuck()
        {
            return _chance.TryLuck();
        }
    }
}