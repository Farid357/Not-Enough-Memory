using System;
using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class LateGameUpdate : ILateGameUpdate, ILateUpdateble
    {
        private readonly List<ILateUpdateble> _updateables = new();

        public IReadOnlyList<ILateUpdateble> Updateables => _updateables;
        
        public void LateUpdate()
        {
            _updateables.ForEach(updateable => updateable.LateUpdate());
        }

        public void Add(params ILateUpdateble[] updateables)
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