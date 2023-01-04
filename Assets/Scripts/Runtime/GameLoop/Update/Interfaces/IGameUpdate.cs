using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public interface IGameUpdate
    {
        IReadOnlyList<IUpdateable> Updateables { get; }

        void Add(params IUpdateable[] updateables);
        
        void Remove(IUpdateable updateable);
    }
}