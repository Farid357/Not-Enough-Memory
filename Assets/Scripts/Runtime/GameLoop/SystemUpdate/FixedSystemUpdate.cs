using System;
using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public sealed class FixedSystemUpdate : IFixedSystemUpdate
    {
        private readonly List<IFixedUpdateable> _updateables = new();
        
        public IReadOnlyList<IFixedUpdateable> Updateables => _updateables;

        public void FixedUpdate(float fixedDeltaTime)
        {
            _updateables.ForEach(updateable => updateable.FixedUpdate(fixedDeltaTime));
        }
        
        public void Add(params IFixedUpdateable[] updateables)
        {
            if (updateables == null)
                throw new ArgumentNullException(nameof(updateables));

            foreach (var updateable in updateables)
            {
                _updateables.Add(updateable);
            }
        }
    }
}