﻿namespace NotEnoughMemory.Model
{
    public sealed class FiftyFiftyChance : IChance
    {
        private readonly System.Random _random = new();
        
        public bool TryLuck()
        {
            return _random.Next(0, 2) == 0;
        }
    }
}