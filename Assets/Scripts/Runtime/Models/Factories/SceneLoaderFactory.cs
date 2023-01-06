using System;
using System.ComponentModel;
using NotEnoughMemory.SceneLoading;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;
using UnityEngine.SceneManagement;

namespace NotEnoughMemory.Factories
{
    public sealed class SceneLoaderFactory : IFactory<ISceneLoader>
    {
        private readonly SceneLoadMode _sceneLoadMode;
        private readonly IScreen _screen;
        private readonly IWindow _loadingWindow;
        private readonly ISceneLoadingView _sceneLoadingView;

        public SceneLoaderFactory(SceneLoadMode sceneLoadMode, IWindow loadingWindow, IScreen screen, ISceneLoadingView sceneLoadingView)
        {
            if (!Enum.IsDefined(typeof(SceneLoadMode), sceneLoadMode))
                throw new InvalidEnumArgumentException(nameof(sceneLoadMode), (int)sceneLoadMode, typeof(SceneLoadMode));

            _sceneLoadMode = sceneLoadMode;
            _loadingWindow = loadingWindow ?? throw new ArgumentNullException(nameof(loadingWindow));
            _screen = screen ?? throw new ArgumentNullException(nameof(screen));
            _sceneLoadingView = sceneLoadingView ?? throw new ArgumentNullException(nameof(sceneLoadingView));
        }

        public ISceneLoader Create()
        {
            var unitySceneLoader = new UnitySceneLoader(LoadSceneMode.Additive);
            
            return _sceneLoadMode switch
            {
                SceneLoadMode.Simple => new UnitySceneLoader(LoadSceneMode.Single),
                SceneLoadMode.WithLoadScreen => new SceneLoaderWithLoadingScreen(_loadingWindow, unitySceneLoader, _sceneLoadingView),
                SceneLoadMode.WithFadeScreen => new SceneLoaderWithFadeScreen(_screen, unitySceneLoader),
                _ => throw new ArgumentOutOfRangeException(nameof(_sceneLoadMode))
            };
        }
    }
}