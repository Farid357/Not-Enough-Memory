﻿using System;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameEngineLoopFixedUpdate : IGameEngineLoopUpdate
    {
        public void Update(IGameLoop gameLoop, IGameTime gameTime)
        {
            if (gameLoop == null) 
                throw new ArgumentNullException(nameof(gameLoop));
            
            if (gameTime == null) 
                throw new ArgumentNullException(nameof(gameTime));

            gameLoop.FixedUpdate(gameTime.FixedDelta);
        }
    }
}