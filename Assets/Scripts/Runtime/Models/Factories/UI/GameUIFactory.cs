using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.SceneLoading;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class GameUIFactory : IGameUIFactory
    {
        private readonly IUI _ui;
        private readonly IScenes _scenes;
        private readonly ISceneLoader _sceneLoader;

        public GameUIFactory(IUI ui, IScenes scenes, ISceneLoader sceneLoader)
        {
            _ui = ui ?? throw new ArgumentNullException(nameof(ui));
            _scenes = scenes ?? throw new ArgumentNullException(nameof(scenes));
            _sceneLoader = sceneLoader ?? throw new ArgumentNullException(nameof(sceneLoader));
        }

        public void Create()
        {
            _ui.UnityButtons.Exit.Init(new SceneLoadButton(_sceneLoader, _scenes.Menu));
        }
    }
}