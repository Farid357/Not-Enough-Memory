using System;
using System.Threading.Tasks;
using NotEnoughMemory.UI;
using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoaderWithLoadingScreen : ISceneLoader
    {
        private readonly IWindow _loadingWindow;
        private readonly IUnitySceneLoader _unitySceneLoader;
        private readonly ISceneLoadingView _sceneLoadingView;

        public SceneLoaderWithLoadingScreen(IWindow loadingWindow, IUnitySceneLoader unitySceneLoader, ISceneLoadingView sceneLoadingView)
        {
            _loadingWindow = loadingWindow ?? throw new ArgumentNullException(nameof(loadingWindow));
            _unitySceneLoader = unitySceneLoader ?? throw new ArgumentNullException(nameof(unitySceneLoader));
            _sceneLoadingView = sceneLoadingView ?? throw new ArgumentNullException(nameof(sceneLoadingView));
        }

        public async void Load(IScene scene)
        {
            if (scene is null)
                throw new ArgumentNullException(nameof(scene));

            _loadingWindow.Open();
            var time = 0f;
            const float loadingTime = 2f;
            const float toPercents = 100f;

            while (time < loadingTime)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                var progress = Mathf.Lerp(0, 1, time / loadingTime);
                _sceneLoadingView.Visualize(progress);
                time += 0.1f;
            }

            var sceneLoadOperation = _unitySceneLoader.LoadAsync(scene);

            while (!sceneLoadOperation.isDone)
            {
                await Task.Yield();
                _sceneLoadingView.Visualize(sceneLoadOperation.progress);
            }
        }
    }
}