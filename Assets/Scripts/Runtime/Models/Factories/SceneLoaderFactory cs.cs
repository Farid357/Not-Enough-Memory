using System;
using System.ComponentModel;
using NotEnoughMemory.SceneLoading;

namespace NotEnoughMemory.Factories
{
    public sealed class SceneLoaderFactory : IFactory<ISceneLoader>
    {
        private readonly SceneLoadMode _sceneLoadMode;
        private readonly IScreenFade _screenFade;
        private readonly ISceneData _loaderScene;

        public SceneLoaderFactory(SceneLoadMode sceneLoadMode, ISceneData loaderScene)
        {
            if (!Enum.IsDefined(typeof(SceneLoadMode), sceneLoadMode))
                throw new InvalidEnumArgumentException(nameof(sceneLoadMode), (int)sceneLoadMode,
                    typeof(SceneLoadMode));

            _sceneLoadMode = sceneLoadMode;
            _loaderScene = loaderScene ?? throw new ArgumentNullException(nameof(loaderScene));
        }

        public ISceneLoader Create()
        {
            return _sceneLoadMode switch
            {
                SceneLoadMode.Simple => new StandardSceneLoader(),
                SceneLoadMode.WithLoadScreen => new SceneLoaderWithScreen(_loaderScene),
                _ => throw new ArgumentOutOfRangeException(nameof(_sceneLoadMode))
            };
        }
    }
}