using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoaderWithScreen : ISceneLoader
    {
        private readonly IScene _loaderScene;
        private readonly IUnitySceneLoader _unitySceneLoader;
        private readonly ISceneLoadingView _sceneLoadingView;

        public SceneLoaderWithScreen(IScene loaderScene, IUnitySceneLoader unitySceneLoader, ISceneLoadingView sceneLoadingView)
        {
            _loaderScene = loaderScene ?? throw new ArgumentNullException(nameof(loaderScene));
            _unitySceneLoader = unitySceneLoader ?? throw new ArgumentNullException(nameof(unitySceneLoader));
            _sceneLoadingView = sceneLoadingView ?? throw new ArgumentNullException(nameof(sceneLoadingView));
        }

        public async void Load(IScene scene)
        {
            if (scene is null)
                throw new ArgumentNullException(nameof(scene));

            var loadScreenOperation = _unitySceneLoader.LoadAsync(_loaderScene);
            await loadScreenOperation;
            LoadNext(scene);
        }

        private async void LoadNext(IScene scene)
        {
            var time = 0f;
            const float loadingTime = 2f;
            const float toPercents = 100f;

            while (time < loadingTime)
            {
                await Task.Delay(TimeSpan.FromSeconds(0.1f));
                var progress = Mathf.Lerp(0, 1, time / loadingTime);
                _sceneLoadingView.Visualize(progress * toPercents);
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