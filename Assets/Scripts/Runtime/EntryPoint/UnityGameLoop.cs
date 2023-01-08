using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class UnityGameLoop : IGameEngineLoop
    {
        private readonly List<(IGameLoop, IGameTime)> _gameLoops = new();
        
        public void Add(IGameLoop gameLoop, IGameTime gameTime)
        {
            if (gameLoop == null) 
                throw new ArgumentNullException(nameof(gameLoop));
            
            if (gameTime == null) 
                throw new ArgumentNullException(nameof(gameTime));
            
            _gameLoops.Add((gameLoop, gameTime));
            UpdateAll(UniTask.Yield(), new GameEngineLoopUpdate());
            UpdateAll(UniTask.Yield(PlayerLoopTiming.PostLateUpdate), new GameEngineLoopLateUpdate());
            UpdateAll(UniTask.WaitForFixedUpdate(), new GameEngineLoopFixedUpdate());
        }

        private async UniTaskVoid UpdateAll(YieldAwaitable yieldAwaitable, IGameEngineLoopUpdate gameEngineLoopUpdate)
        {
            while (true)
            {
                await yieldAwaitable;

                foreach (var (loop, time) in _gameLoops)
                {
                   if(time.IsActive)
                       gameEngineLoopUpdate.Update(loop, time);
                }
            }
        }
    }
}