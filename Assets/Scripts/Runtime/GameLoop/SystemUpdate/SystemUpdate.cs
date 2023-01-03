using System;
using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public sealed class SystemUpdate : ISystemUpdate
    {
        private readonly List<IUpdateable> _updateables;

        public SystemUpdate(List<IUpdateable> updateables)
        {
            _updateables = updateables ?? throw new ArgumentNullException(nameof(updateables));
        }

        public SystemUpdate() : this(new List<IUpdateable>())
        {
        }

        public IReadOnlyList<IUpdateable> Updateables => _updateables;

        public void Update(float deltaTime)
        {
            _updateables.ForEach(updateable => updateable.Update(deltaTime));
        }

        public void Add(params IUpdateable[] updateables)
        {
            if (updateables == null)
                throw new ArgumentNullException(nameof(updateables));

            _updateables.AddRange(updateables);
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