using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public interface ILateGameUpdate
    {
        IReadOnlyList<ILateUpdateable> Updateables { get; }
        
        void Add(params ILateUpdateable[] updateables);
    }
}