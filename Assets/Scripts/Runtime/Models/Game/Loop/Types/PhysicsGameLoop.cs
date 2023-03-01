using System;
using Cysharp.Threading.Tasks;
using NotEnoughMemory.Model.Tools;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class PhysicsGameLoop : IGameLoop
    {
        private readonly IReadOnlyGameTime _gameTime;
        private readonly GameLoopObjects _gameLoopObjects = new();
        private readonly float _timeStep;

        public PhysicsGameLoop(IReadOnlyGameTime gameTime, float timeStep)
        {
            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
            _timeStep = timeStep.ThrowIfLessOrEqualsToZeroException();
        }

        public IGameLoopObjects Objects => _gameLoopObjects;

        public async void Start()
        {
            while (true)
            {
                if (_gameTime.IsActive)
                {
                    _gameLoopObjects.Update(_gameTime.FixedDelta);
                    await UniTask.Delay(TimeSpan.FromSeconds(_timeStep));
                }

                else
                {
                    await UniTask.Yield(PlayerLoopTiming.Update);
                }
            }
        }
    }
}