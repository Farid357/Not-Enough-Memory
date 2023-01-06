using System;
using NotEnoughMemory.SceneLoading;

namespace NotEnoughMemory.UI
{
    public sealed class SceneLoadButton : IButton
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IScene _scene;

        public SceneLoadButton(ISceneLoader sceneLoader, IScene scene)
        {
            _sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));
            _scene = scene ?? throw new ArgumentNullException(nameof(scene));
        }

        public void Press()
        {
            _sceneLoader.Load(_scene);
        }
    }
}