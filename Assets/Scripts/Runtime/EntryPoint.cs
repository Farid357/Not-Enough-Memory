using NotEnoughMemory.Audio;
using NotEnoughMemory.Game;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.SceneLoading;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ViewData _view;
        [SerializeField] private UIData _ui;
        [SerializeField] private AudioData _audio;
        [SerializeField] private ScenesData _scenes;
        [SerializeField] private SceneLoader _sceneLoader;
        
        private readonly IGameLoop _gameLoop = new GameLoop();
        private IGame _game;

        private void Awake()
        {
            var gameData = new GameData(_view, _ui, _scenes, _audio);
            _game = new Game.Game(gameData, _gameLoop, _sceneLoader);
        }

        private void FixedUpdate()
        {
            if (_game.IsNotPaused)
                _gameLoop.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            if (_game.IsNotPaused)
                _gameLoop.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (_game.IsNotPaused)
                _gameLoop.LateUpdate();
        }
    }
}