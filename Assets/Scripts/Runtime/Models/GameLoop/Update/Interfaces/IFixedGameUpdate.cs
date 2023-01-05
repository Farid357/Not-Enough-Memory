using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public interface IFixedGameUpdate
    {
        IReadOnlyList<IFixedUpdateable> Updateables { get; }

        void Add(params IFixedUpdateable[] updateables);
    }
}