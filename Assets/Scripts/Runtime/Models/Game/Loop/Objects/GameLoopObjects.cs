using System;
using System.Collections.Generic;
using System.Linq;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoopObjects : IGameLoopObjects, IGameLoopObject
    {
        private readonly List<IGameLoopObject> _all;

        public GameLoopObjects(params IGameLoopObject[] objects)
        {
            if (objects == null)
                throw new ArgumentNullException(nameof(objects));
            
            _all = objects.ToList();
        }

        public GameLoopObjects() : this(Array.Empty<IGameLoopObject>())
        {
        }

        public IReadOnlyList<IGameLoopObject> All => _all;

        public void Update(float deltaTime)
        {
            _all.ForEach(updateable => updateable.Update(deltaTime));
        }

        public void Add(IGameLoopObject loopObject)
        {
            if (loopObject == null)
                throw new ArgumentNullException(nameof(loopObject));

            _all.Add(loopObject);
        }
    }
}