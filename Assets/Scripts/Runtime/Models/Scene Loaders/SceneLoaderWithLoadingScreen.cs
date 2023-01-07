using System;
using System.Threading.Tasks;
using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoaderWithLoadingScreen : ISceneLoader
    {
        private readonly IWindow _loadingWindow;
        private readonly IGameEngineSceneLoader _gameEngineSceneLoader;
        private readonly ISceneLoadingView _sceneLoadingView;

        public SceneLoaderWithLoadingScreen(IWindow loadingWindow, IGameEngineSceneLoader gameEngineSceneLoader, ISceneLoadingView sceneLoadingView)
        {
            _loadingWindow = loadingWindow ?? throw new ArgumentNullException(nameof(loadingWindow));
            _gameEngineSceneLoader = gameEngineSceneLoader ?? throw new ArgumentNullException(nameof(gameEngineSceneLoader));
            _sceneLoadingView = sceneLoadingView ?? throw new ArgumentNullException(nameof(sceneLoadingView));
        }

        public async void Load(IScene scene)
        {
            if (scene is null)
                throw new ArgumentNullException(nameof(scene));

            _loadingWindow.Open();
            var time = 0f;
            const float loadingTime = 2f;

            while (time < loadingTime)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                var progress = Mathf.Lerp(0, 1, time / loadingTime);
                _sceneLoadingView.Visualize(progress);
                time += 0.1f;
            }

            var sceneLoadOperation = _gameEngineSceneLoader.LoadAsync(scene);

            while (!sceneLoadOperation.isDone)
            {
                await Task.Yield();
                _sceneLoadingView.Visualize(sceneLoadOperation.progress);
            }
        }
    }
}