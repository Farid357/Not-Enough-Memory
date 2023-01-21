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
        
        private void Awake()
        {
            IGameEngine gameEngine = new Game.Unity(_views, _ui, _scenes, new UnitySceneLoader(LoadSceneMode.Single));
            IGame game = new Game.Game(gameEngine);
            game.Play();
        }
    }
}