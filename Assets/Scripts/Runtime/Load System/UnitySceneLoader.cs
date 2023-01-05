using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotEnoughMemory.SceneLoading
{
    public sealed class UnitySceneLoader : IUnitySceneLoader
    {
        private readonly LoadSceneMode _loadSceneMode;

        public UnitySceneLoader(LoadSceneMode loadSceneMode)
        {
            _loadSceneMode = loadSceneMode;
        }

        public void Load(IScene scene)
        {
            SceneManager.LoadScene(scene.Name, _loadSceneMode);
        }
        
        public AsyncOperation LoadAsync(IScene scene)
        {
            return SceneManager.LoadSceneAsync(scene.Name, _loadSceneMode);
        }
    }
}