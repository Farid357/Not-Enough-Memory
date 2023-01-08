using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public interface IGameEngineLoopsUpdate
    {
        void Update(IEnumerable<(IGameLoop gameLoop, IGameTime gameTime)> gameLoops);
    }
}