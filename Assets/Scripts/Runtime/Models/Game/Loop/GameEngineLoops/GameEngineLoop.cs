using System;
using Cysharp.Threading.Tasks;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameEngineLoop : IGameEngineLoop
    {
        private readonly IGameTime _gameTime;
        private readonly IGameLoop _gameLoop;

        public GameEngineLoop(IGameTime gameTime, IGameLoop gameLoop)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        public void UpdateLoop()
        {
            UpdateAll(UniTask.Yield(), new GameEngineLoopUpdate());
            UpdateAll(UniTask.Yield(PlayerLoopTiming.PostLateUpdate), new GameEngineLoopLateUpdate());
            UpdateAll(UniTask.WaitForFixedUpdate(), new GameEngineLoopFixedUpdate());
        }

        private async UniTaskVoid UpdateAll(YieldAwaitable yieldAwaitable, IGameEngineLoopUpdate gameEngineLoopUpdate)
        {
            while (true)
            {
                await yieldAwaitable;

                if (_gameTime.IsActive)
                    gameEngineLoopUpdate.Update(_gameLoop, _gameTime);
            }
        }

    }
}