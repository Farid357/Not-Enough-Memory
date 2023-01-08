using System;
using System.Collections.Generic;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class UnityGameLoop : IGameEngineLoop
    {
        private readonly List<(IGameLoop, IGameTime)> _gameLoops = new();
        private readonly IGameEngineLoopsUpdate _gameEngineLoopsUpdate;
        private readonly IGameEngineLoopsUpdate _gameEngineLoopsFixedUpdate;
        private readonly IGameEngineLoopsUpdate _gameEngineLoopsLateUpdate;

        public UnityGameLoop()
        {
            _gameEngineLoopsUpdate = new GameEngineLoopsUpdate();
            _gameEngineLoopsFixedUpdate = new GameEngineLoopsFixedUpdate();
            _gameEngineLoopsLateUpdate = new GameEngineLoopsLateUpdate();
        }
        
        public void Add(IGameLoop gameLoop, IGameTime gameTime)
        {
            if (gameLoop == null) 
                throw new ArgumentNullException(nameof(gameLoop));
            
            if (gameTime == null) 
                throw new ArgumentNullException(nameof(gameTime));
            
            _gameLoops.Add((gameLoop, gameTime));
            _gameEngineLoopsUpdate.Update(_gameLoops);
            _gameEngineLoopsFixedUpdate.Update(_gameLoops);
            _gameEngineLoopsLateUpdate.Update(_gameLoops);
        }
    }
}