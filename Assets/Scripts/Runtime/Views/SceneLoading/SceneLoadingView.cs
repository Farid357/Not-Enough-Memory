namespace NotEnoughMemory.SceneLoading
{
    public sealed class SceneLoadingView : ISceneLoadingView
    {
        public void Visualize(float progress)
        {
            LoadingText.Visualize(progress);
            LoadingBar.Visualize(progress);
        }
    }
}