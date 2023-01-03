using System.Collections.Generic;

namespace NotEnoughMemory.GameLoop
{
    public interface ILateSystemUpdate : ILateUpdateable
    {
        IReadOnlyList<ILateUpdateable> Updateables { get; }
        
        void Add(params ILateUpdateable[] updateables);
    }
}