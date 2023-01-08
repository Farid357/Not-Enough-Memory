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
            UpdateAll(UniTask.Yield(), new GameLoopUpdate(_gameTime));
            UpdateAll(UniTask.Yield(PlayerLoopTiming.PostLateUpdate), new GameLoopLateUpdate());
            UpdateAll(UniTask.WaitForFixedUpdate(), new GameLoopFixedUpdate(_gameTime));
        }

        private async UniTaskVoid UpdateAll(YieldAwaitable yieldAwaitable, IGameLoopUpdate gameLoopUpdate)
        {
            while (true)
            {
                await yieldAwaitable;

                if (_gameTime.IsActive)
                    gameLoopUpdate.Update(_gameLoop);
            }
        }

    }
}