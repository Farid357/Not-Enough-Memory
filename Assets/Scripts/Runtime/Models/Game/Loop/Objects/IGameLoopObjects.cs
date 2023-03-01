using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface IGameLoopObjects
    {
        IReadOnlyList<IGameLoopObject> All { get; }

        void Add(IGameLoopObject loopObject);

    }
}