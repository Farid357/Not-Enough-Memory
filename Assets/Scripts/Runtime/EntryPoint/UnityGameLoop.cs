using System;
using NotEnoughMemory.Game;
using NotEnoughMemory.Game.Loop;
using UnityEngine;

namespace NotEnoughMemory
{
    public sealed class UnityGameLoop : MonoBehaviour
    {
        private IGameLoop _gameLoop;
        private IGameTime _gameTime;

        public void Init(IGameLoop gameLoop, IGameTime gameTime)
        {
            if (_gameLoop != null)
                throw new InvalidOperationException($"{nameof(UnityGameLoop)} already was inited!");

            _gameTime = gameTime ?? throw new ArgumentNullException(nameof(gameTime));
            _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
        }

        private void Update()
        {
            if (_gameTime.IsActive)
                _gameLoop.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (_gameTime.IsActive)
                _gameLoop.LateUpdate();
        }

        private void FixedUpdate()
        {
            if (_gameTime.IsActive)
                _gameLoop.FixedUpdate(Time.fixedDeltaTime);
        }
    }
}