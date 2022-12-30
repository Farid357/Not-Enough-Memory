using System;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneBreaker : ITelephoneBreaker
    {
        private readonly IRandom _random = new Random();
        private readonly IChance _brakeChance;

        public TelephoneBreaker(IChance brakeChance)
        {
            _brakeChance = brakeChance ?? throw new ArgumentNullException(nameof(brakeChance));
        }

        public TelephoneBreaker() : this(new OneQuarterChance())
        {
            
        }
        
        public bool TryBreak(ITelephone telephone)
        {
            if (telephone is null)
                throw new ArgumentNullException(nameof(telephone));
            
            if (_random.TryGetLuckyNumberFrom(_brakeChance))
            {
                telephone.Break();
                return true;
            }

            return false;
        }
    }
}