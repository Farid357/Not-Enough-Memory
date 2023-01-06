using System;
using System.ComponentModel;
using IceCream.LoadSystem;
using NotEnoughMemory.SceneLoading;
using NotEnoughMemory.View;
using UnityEngine.SceneManagement;

namespace NotEnoughMemory.Factories
{
    public sealed class SceneLoaderFactory : IFactory<ISceneLoader>
    {
        private readonly SceneLoadMode _sceneLoadMode;
        private readonly IScreen _screen;
        private readonly IScene _loaderScene;
        private readonly ISceneLoadingView _sceneLoadingView;

        public SceneLoaderFactory(SceneLoadMode sceneLoadMode, IScene loaderScene, IScreen screen, ISceneLoadingView sceneLoadingView)
        {
            if (!Enum.IsDefined(typeof(SceneLoadMode), sceneLoadMode))
                throw new InvalidEnumArgumentException(nameof(sceneLoadMode), (int)sceneLoadMode, typeof(SceneLoadMode));

            _sceneLoadMode = sceneLoadMode;
            _loaderScene = loaderScene ?? throw new ArgumentNullException(nameof(loaderScene));
            _screen = screen ?? throw new ArgumentNullException(nameof(screen));
            _sceneLoadingView = sceneLoadingView ?? throw new ArgumentNullException(nameof(sceneLoadingView));
        }

        public ISceneLoader Create()
        {
            var unitySceneLoader = new UnitySceneLoader(LoadSceneMode.Additive);
            
            return _sceneLoadMode switch
            {
                SceneLoadMode.Simple => new UnitySceneLoader(LoadSceneMode.Single),
                SceneLoadMode.WithLoadScreen => new SceneLoaderWithScreen(_loaderScene, unitySceneLoader, _sceneLoadingView),
                SceneLoadMode.WithFadeScreen => new SceneLoaderWithFadeScreen(_screen, unitySceneLoader),
                _ => throw new ArgumentOutOfRangeException(nameof(_sceneLoadMode))
            };
        }
    }
}