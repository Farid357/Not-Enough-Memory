using System;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoopFixedUpdate : IGameLoopUpdate
    {
        private readonly IGameTime _gameTime;

        public GameLoopFixedUpdate(IGameTime gameTime)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }
        
        public void Update(IGameLoop gameLoop)
        {
            if (gameLoop == null) 
                throw new ArgumentNullException(nameof(gameLoop));

            gameLoop.FixedUpdate(_gameTime.FixedDelta);
        }
    }
}