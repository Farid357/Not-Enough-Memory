using System;
using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameUpdate : IGameUpdate, IUpdateble
    {
        private readonly List<IUpdateble> _updateables;

        public GameUpdate(List<IUpdateble> updateables)
        {
            _updateables = updateables ?? throw new ArgumentNullException(nameof(updateables));
        }

        public GameUpdate() : this(new List<IUpdateble>())
        {
        }

        public IReadOnlyList<IUpdateble> Updateables => _updateables;

        public void Update(float deltaTime)
        {
            _updateables.ForEach(updateable => updateable.Update(deltaTime));
        }

        public void Add(params IUpdateble[] updateables)
        {
            if (updateables == null)
                throw new ArgumentNullException(nameof(updateables));

            _updateables.AddRange(updateables);
        }

        public void Remove(IUpdateble updateble)
        {
            if (updateble == null)
                throw new ArgumentNullException(nameof(updateble));

            if (_updateables.Contains(updateble) == false)
                throw new InvalidOperationException($"{nameof(GameUpdate)} doesn't contain {updateble}");

            _updateables.Remove(updateble);
        }
    }
}