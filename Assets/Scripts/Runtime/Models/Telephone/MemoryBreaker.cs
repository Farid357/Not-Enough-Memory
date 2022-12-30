using System;

namespace NotEnoughMemory.Model
{
    public sealed class MemoryBreaker : IMemoryBreaker
    {
        private readonly IRandom _random = new Random();
        private readonly IChance _brakeChance;

        public MemoryBreaker(IChance brakeChance)
        {
            _brakeChance = brakeChance ?? throw new ArgumentNullException(nameof(brakeChance));
        }

        public MemoryBreaker() : this(new OneQuarterChance())
        {
            
        }
        
        public bool TryBreak(IMemory memory)
        {
            if (memory is null)
                throw new ArgumentNullException(nameof(memory));
            
            if (_random.TryGetLuckyNumberFrom(_brakeChance))
            {
                memory.Break();
                return true;
            }

            return false;
        }
    }
}