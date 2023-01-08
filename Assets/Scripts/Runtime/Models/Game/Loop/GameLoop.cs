using System;
using Cysharp.Threading.Tasks;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IReadOnlyGameTime _gameTime;
        private readonly LateGameUpdate _lateGameUpdate = new();
        private readonly FixedGameUpdate _fixedGameUpdate = new();
        private readonly GameUpdate _gameUpdate = new();

        public GameLoop(IReadOnlyGameTime gameTime)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
        }

        public ILateGameUpdate LateGameUpdate => _lateGameUpdate;

        public IFixedGameUpdate FixedGameUpdate => _fixedGameUpdate;

        public IGameUpdate GameUpdate => _gameUpdate;

        public void Update()
        {
            UpdateAll(UniTask.Yield(), () => _gameUpdate.Update(_gameTime.Delta));
            UpdateAll(UniTask.Yield(PlayerLoopTiming.PostLateUpdate), () => _lateGameUpdate.LateUpdate());
            UpdateAll(UniTask.WaitForFixedUpdate(), () => _fixedGameUpdate.FixedUpdate(_gameTime.FixedDelta));
        }

        public async void UpdateAll(YieldAwaitable yieldAwaitable, Action updateAction)
        {
            while (true)
            {
                await yieldAwaitable;

                if (_gameTime.IsActive)
                    updateAction.Invoke();
            }
        }
    }
}