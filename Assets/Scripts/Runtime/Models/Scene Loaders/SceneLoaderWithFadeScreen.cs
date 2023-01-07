using System;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoaderWithFadeScreen : ISceneLoader
    {
        private readonly IScreen _screen;
        private readonly IGameEngineSceneLoader _sceneLoader;

        public SceneLoaderWithFadeScreen(IScreen screen, IGameEngineSceneLoader sceneLoader)
        {
            _screen = screen ?? throw new ArgumentNullException(nameof(screen));
            _sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));
        }

        public async void Load(IScene scene)
        {
            if (scene is null)
                throw new ArgumentNullException(nameof(scene));
            
            await _screen.FadeIn();
            _sceneLoader.LoadAsync(scene);
            _screen.FadeOut();
        }
    }
}
