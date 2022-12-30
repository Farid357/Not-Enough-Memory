using System;
using System.Collections.Generic;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.GameLoop
{
    public sealed class LateSystemUpdate : ILateUpdateable
    {
        private readonly IList<ILateUpdateable> _updateables = new List<ILateUpdateable>();
        
        public void LateUpdate(float deltaTime)
        {
            _updateables.ForEach(updateable => updateable.LateUpdate(deltaTime));
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