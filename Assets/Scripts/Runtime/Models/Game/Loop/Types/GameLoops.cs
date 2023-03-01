using System;
using System.Collections.Generic;
using System.Linq;

namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoops : IGameLoop
    {
        private readonly List<IGameLoop> _gameLoops;

        public GameLoops(IGameLoop[] gameLoops)
        {
            if (gameLoops == null)
                throw new ArgumentNullException(nameof(gameLoops));
            
            if (gameLoops.Length == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(gameLoops));
            
            _gameLoops = gameLoops.ToList();
        }

        public IGameLoopObjects Objects
        {
            get
            {
                var gameLoopObjects = new GameLoopObjects();

                foreach (var gameLoopObject in _gameLoops.SelectMany(gameLoop => gameLoop.Objects.All))
                {
                    gameLoopObjects.Add(gameLoopObject);
                }

                return gameLoopObjects;
            }
        }

        public void Start()
        {
            foreach (var gameLoop in _gameLoops)
            {
                gameLoop.Start();
            }
        }
    }
}