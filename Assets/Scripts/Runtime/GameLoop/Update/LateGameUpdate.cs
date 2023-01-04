using System;
using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public sealed class LateGameUpdate : ILateGameUpdate, ILateUpdateable
    {
        private readonly List<ILateUpdateable> _updateables = new();

        public IReadOnlyList<ILateUpdateable> Updateables => _updateables;
        
        public void LateUpdate()
        {
            _updateables.ForEach(updateable => updateable.LateUpdate());
        }

        public void Add(params ILateUpdateable[] updateables)
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