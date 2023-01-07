namespace NotEnoughMemory.Model
{
    public sealed class OneQuarterChance : IChance
    {
        private readonly System.Random _random = new();
        
        public bool TryLuck()
        {
            return _random.Next(0, 4) == 0;
        }
    }
}