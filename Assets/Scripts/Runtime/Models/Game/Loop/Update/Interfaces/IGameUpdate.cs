using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface IGameUpdate
    {
        IReadOnlyList<IUpdateable> Updateables { get; }

        void Add(params IUpdateable[] updateables);
        
    }
}