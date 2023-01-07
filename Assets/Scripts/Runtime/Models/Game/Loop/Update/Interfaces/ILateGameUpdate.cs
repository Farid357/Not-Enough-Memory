using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface ILateGameUpdate
    {
        IReadOnlyList<ILateUpdateable> Updateables { get; }
        
        void Add(params ILateUpdateable[] updateables);
    }
}