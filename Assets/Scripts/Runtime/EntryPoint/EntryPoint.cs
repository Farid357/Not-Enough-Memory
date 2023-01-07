using NotEnoughMemory.Game;
using NotEnoughMemory.Model;
using NotEnoughMemory.SceneLoading;
using NotEnoughMemory.View;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotEnoughMemory
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Views _views;
        [SerializeField] private UI.UI _ui;
        [SerializeField] private Scenes _scenes;
        
        private IGame _game;

        private void Awake()
        {
            IGameEngine gameEngine = new Game.Unity(_views, _ui, _scenes, new UnitySceneLoader(LoadSceneMode.Single));
            _game = new Game.Game(gameEngine);
        }

        private void FixedUpdate()
        {
            if (_game.Time.IsActive)
                _game.Loop.FixedUpdate(Time.fixedDeltaTime);
        }


        private void Update()
        {
            if (_game.Time.IsActive)
                _game.Loop.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            if (_game.Time.IsActive)
                _game.Loop.LateUpdate();
        }
    }
}