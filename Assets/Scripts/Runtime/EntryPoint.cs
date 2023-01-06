using NotEnoughMemory.Game;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.SceneLoading;
using UnityEngine;

namespace NotEnoughMemory
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private View.Views _views;
        [SerializeField] private UI.UI _ui;
        [SerializeField] private Scenes _scenes;
        [SerializeField] private SceneLoader _sceneLoader;

        private readonly IGameLoop _gameLoop = new GameLoop();
        private IGame _game;

        private void Awake()
        {
            var gameData = new Game.Unity(_views, _ui, _scenes, _sceneLoader);
            _game = new Game.Game(gameData, _gameLoop);
        }

        private void FixedUpdate()
        {
            if (_game.Time.IsActive)
                _gameLoop.FixedUpdate(Time.fixedDeltaTime);
        }


        private void Update()
        {
            if (_game.Time.IsActive)
                _gameLoop.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (_game.Time.IsActive)
                _gameLoop.LateUpdate();
        }
    }
}