using NotEnoughMemory.SceneLoading;
using UnityEngine;

namespace NotEnoughMemory.Model
{
    public sealed class Scenes : MonoBehaviour, IScenes
    {
        [SerializeField] private Scene _menu;
        [SerializeField] private Scene _game;

        public IScene Menu => _menu;
        
        public IScene Game => _game;

    }
}