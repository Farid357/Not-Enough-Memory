using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface IFixedGameUpdate
    {
        IReadOnlyList<IFixedUpdateable> Updateables { get; }

        void Add(params IFixedUpdateable[] updateables);
    }
}