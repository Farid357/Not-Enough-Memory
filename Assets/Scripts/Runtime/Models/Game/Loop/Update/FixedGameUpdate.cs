using System;
using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class FixedGameUpdate : IFixedGameUpdate, IFixedUpdateble
    {
        private readonly List<IFixedUpdateble> _updatebles = new();
        
        public IReadOnlyList<IFixedUpdateble> Updatebles => _updatebles;

        public void FixedUpdate(float fixedDeltaTime)
        {
            _updatebles.ForEach(updateable => updateable.FixedUpdate(fixedDeltaTime));
        }
        
        public void Add(params IFixedUpdateble[] updatebles)
        {
            if (updatebles == null)
                throw new ArgumentNullException(nameof(updatebles));

            foreach (var updateable in updatebles)
            {
                _updatebles.Add(updateable);
            }
        }
    }
}