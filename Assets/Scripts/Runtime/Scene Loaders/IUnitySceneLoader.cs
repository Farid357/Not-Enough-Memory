using UnityEngine;

namespace NotEnoughMemory.SceneLoading
{
    public interface IUnitySceneLoader : ISceneLoader
    {
        AsyncOperation LoadAsync(IScene scene);
    }
}