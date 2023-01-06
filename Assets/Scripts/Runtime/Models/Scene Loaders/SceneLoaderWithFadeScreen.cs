using System;
using NotEnoughMemory.View;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoaderWithFadeScreen : ISceneLoader
    {
        private readonly IScreen _screen;
        private readonly IUnitySceneLoader _unitySceneLoader;

        public SceneLoaderWithFadeScreen(IScreen screen, IUnitySceneLoader unitySceneLoader)
        {
            _screen = screen ?? throw new ArgumentNullException(nameof(screen));
            _unitySceneLoader = unitySceneLoader ?? throw new ArgumentNullException(nameof(unitySceneLoader));
        }

        public async void Load(IScene scene)
        {
            if (scene is null)
                throw new ArgumentNullException(nameof(scene));
            
            await _screen.FadeIn();
            _unitySceneLoader.LoadAsync(scene);
            _screen.FadeOut();
        }
    }
}
