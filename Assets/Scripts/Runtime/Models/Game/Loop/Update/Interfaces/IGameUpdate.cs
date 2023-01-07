using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface IGameUpdate
    {
        IReadOnlyList<IUpdateble> Updateables { get; }

        void Add(params IUpdateble[] updateables);
        
        void Remove(IUpdateble updateble);
    }
}