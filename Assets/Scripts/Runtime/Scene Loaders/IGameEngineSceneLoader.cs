using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    public interface IGameEngineSceneLoader : ISceneLoader
    {
        AsyncOperation LoadAsync(IScene scene);
    }
}