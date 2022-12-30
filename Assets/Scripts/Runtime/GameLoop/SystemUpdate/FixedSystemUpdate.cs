using System;
using System.Collections.Generic;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.GameLoop
{
    public sealed class FixedSystemUpdate : IFixedUpdateable
    {
        private readonly IList<IFixedUpdateable> _updateables = new List<IFixedUpdateable>();

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