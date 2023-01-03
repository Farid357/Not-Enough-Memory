using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public interface IFixedSystemUpdate : IFixedUpdateable
    {
        IReadOnlyList<IFixedUpdateable> Updateables { get; }

        void Add(params IFixedUpdateable[] updateables);
    }
}