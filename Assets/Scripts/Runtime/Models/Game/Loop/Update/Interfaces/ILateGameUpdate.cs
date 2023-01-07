using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface ILateGameUpdate
    {
        IReadOnlyList<ILateUpdateble> Updateables { get; }
        
        void Add(params ILateUpdateble[] updateables);
    }
}