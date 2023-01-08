using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameEngineLoopsLateUpdate : IGameEngineLoopsUpdate
    {
        public async void Update(IEnumerable<(IGameLoop gameLoop, IGameTime gameTime)> gameLoops)
        {
            if (gameLoops == null) 
                throw new ArgumentNullException(nameof(gameLoops));
            
            while (true)
            {
                await UniTask.Yield(PlayerLoopTiming.LastPostLateUpdate);
                
                foreach (var (gameLoop, gameTime) in gameLoops)
                {
                    if (gameTime.IsActive)
                        gameLoop.LateUpdate();
                }
            }
        }
    }
}