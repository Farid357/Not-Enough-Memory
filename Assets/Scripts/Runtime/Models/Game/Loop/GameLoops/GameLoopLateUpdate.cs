using System;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoopLateUpdate : IGameLoopUpdate
    {
        public void Update(IGameLoop gameLoop)
        {
            if (gameLoop == null)
                throw new ArgumentNullException(nameof(gameLoop));
            
            gameLoop.LateUpdate();
        }
    }
}