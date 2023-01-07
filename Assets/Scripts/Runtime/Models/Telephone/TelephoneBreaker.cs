using System;

namespace NotEnoughMemory.Model
{
    public sealed class TelephoneBreaker : ITelephoneBreaker
    {
        private readonly IRandom _random;

        public TelephoneBreaker(IRandom random)
        {
            _random = random ?? throw new ArgumentNullException(nameof(random));
        }

        public TelephoneBreaker() : this(new Random(new OneQuarterChance()))
        {
            
        }
        
        public bool TryBreak(ITelephone telephone)
        {
            if (telephone is null)
                throw new ArgumentNullException(nameof(telephone));
            
            if (_random.TryLuck())
            {
                telephone.Break();
                return true;
            }

            return false;
        }
    }
}