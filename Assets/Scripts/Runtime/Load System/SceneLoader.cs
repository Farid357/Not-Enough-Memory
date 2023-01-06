using NotEnoughMemory.Factories;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;
using UnityEngine;
using Screen = NotEnoughMemory.View.Screen;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoader : MonoBehaviour, ISceneLoader
    {
        [SerializeField] private SceneLoadMode _mode;
        [SerializeField] private Scene _loadingScene;
        [SerializeField] private Screen _screen;
        [SerializeField] private UIData _ui;
        private IFactory<ISceneLoader> _sceneLoaderFactory;

        private void Awake()
        {
            _sceneLoaderFactory = new SceneLoaderFactory(_mode, _loadingScene, _screen, new SceneLoadingView(_ui.ScrollBars.Loading, 
                new TextView(_ui.Texts.Loading)));
        }

        public void Load(IScene scene)
        {
            var sceneLoader = _sceneLoaderFactory.Create();
            sceneLoader.Load(scene);
        }
    }
}