using NotEnoughMemory.Factories;
using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private SceneData _loadingScene;
        private IFactory<ISceneLoader> _sceneLoaderFactory;

        private void Awake()
        {
            _sceneLoaderFactory = new SceneLoaderFactory(_mode, _loadingScene);
        }

        public void Load(ISceneData sceneData)
        {
            var sceneLoader = _sceneLoaderFactory.Create();
            sceneLoader.Load(sceneData);
        }
    }
}