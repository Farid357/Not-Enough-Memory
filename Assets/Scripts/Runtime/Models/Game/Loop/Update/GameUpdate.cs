using System;
using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameUpdate : IGameUpdate, IUpdateable
    {
        private readonly List<IUpdateable> _updateables;

        public GameUpdate(List<IUpdateable> updateables)
        {
            _updateables = updateables ?? throw new ArgumentNullException(nameof(updateables));
        }

        public GameUpdate() : this(new List<IUpdateable>())
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
                throw new InvalidOperationException($"{nameof(GameUpdate)} doesn't contain {updateable}");

            _updateables.Remove(updateable);
        }
    }
}