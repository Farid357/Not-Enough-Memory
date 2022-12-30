using System;
using System.Collections.Generic;
using NotEnoughtMemory.Model.Tools;

namespace NotEnoughMemory.GameLoop
{
    public sealed class SystemUpdate : ISystemUpdate
    {
        private readonly IList<IUpdateable> _updateables;

        public SystemUpdate(IList<IUpdateable> updateables)
        {
            _updateables = updateables ?? throw new ArgumentNullException(nameof(updateables));
        }

        public SystemUpdate() : this(new List<IUpdateable>())
        {
        }

        public void Update(float deltaTime)
        {
            _updateables.ForEach(updateable => updateable.Update(deltaTime));
        }

        public void Add(params IUpdateable[] updateables)
        {
            if (updateables == null)
                throw new ArgumentNullException(nameof(updateables));

            foreach (var updateable in updateables)
            {
                _updateables.Add(updateable);
            }
        }

        public void Remove(IUpdateable updateable)
        {
            if (updateable == null)
                throw new ArgumentNullException(nameof(updateable));

            if (_updateables.Contains(updateable) == false)
                throw new InvalidOperationException($"{nameof(SystemUpdate)} doesn't contain {updateable}");

            _updateables.Remove(updateable);
        }
    }
}