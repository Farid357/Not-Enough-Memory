using System;
using Cysharp.Threading.Tasks;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IReadOnlyGameTime _gameTime;
        private readonly GameLoopObjects _gameLoopObjects = new();

        public GameLoop(IReadOnlyGameTime gameTime)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public IGameLoopObjects Objects => _gameLoopObjects;

        public async void Start()
        {
            while (true)
            {
                if (_gameTime.IsActive)
                {
                    _gameLoopObjects.Update(_gameTime.Delta);
                    await UniTask.Yield(PlayerLoopTiming.Update);
                }
                
                else
                {
                    await UniTask.Yield(PlayerLoopTiming.Update);
                }
            }
        }
    }
}