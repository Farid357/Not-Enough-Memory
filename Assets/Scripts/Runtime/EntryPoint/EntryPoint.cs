using NotEnoughMemory.Game;
using NotEnoughMemory.Model;
using NotEnoughMemory.View;
using UnityEngine;

namespace NotEnoughMemory
{
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Views _views;
        [SerializeField] private UI.UI _ui;
        [SerializeField] private Scenes _scenes;
        
        private void Awake()
        {
            IGameEngine gameEngine = new Game.Unity(_views, _ui, _scenes);
            IGame game = new Game.Game(gameEngine);
            game.Play();
        }
    }
}