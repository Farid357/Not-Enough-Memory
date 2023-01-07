using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface IFixedGameUpdate
    {
        IReadOnlyList<IFixedUpdateble> Updatebles { get; }

        void Add(params IFixedUpdateble[] updatebles);
    }
}