using UnityEngine.SceneManagement;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class StandardSceneLoader : ISceneLoader
    {
        public void Load(ISceneData sceneData) => SceneManager.LoadSceneAsync(sceneData.Name);
    }
}