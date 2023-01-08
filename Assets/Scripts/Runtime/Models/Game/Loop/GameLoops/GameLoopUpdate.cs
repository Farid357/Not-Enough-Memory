using System;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoopUpdate : IGameLoopUpdate
    {
        private readonly IGameTime _gameTime;

        public GameLoopUpdate(IGameTime gameTime)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public void Update(IGameLoop gameLoop)
        {
            if (gameLoop == null)
                throw new ArgumentNullException(nameof(gameLoop));
            
            gameLoop.Update(_gameTime.Delta);
        }
    }
}