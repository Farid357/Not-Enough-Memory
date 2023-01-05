using NotEnoughMemory.Factories;
using UnityEngine;
using Screen = NotEnoughMemory.View.Screen;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private Scene _loadingScene;
        [SerializeField] private Screen _screen;
        private IFactory<ISceneLoader> _sceneLoaderFactory;

        private void Awake()
        {
            _sceneLoaderFactory = new SceneLoaderFactory(_mode, _loadingScene, _screen);
        }

        public void Load(IScene scene)
        {
            var sceneLoader = _sceneLoaderFactory.Create();
            sceneLoader.Load(scene);
        }
    }
}