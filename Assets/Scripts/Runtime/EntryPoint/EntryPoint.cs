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
        [SerializeField] private UnityGameLoop _unityGameLoop;
        
        private IGame _game;

        private void Awake()
        {
            IGameEngine gameEngine = new Game.Unity(_views, _ui, _scenes, new UnitySceneLoader(LoadSceneMode.Single));
            _game = new Game.Game(gameEngine);
            _unityGameLoop.Init(_game.Loop, _game.Time);
        }
    }
}