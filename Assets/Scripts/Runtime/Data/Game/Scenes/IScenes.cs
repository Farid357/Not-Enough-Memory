using NotEnoughMemory.SceneLoading;

namespace NotEnoughMemory.Model
{
    public interface IScenes
    {
        IScene Menu { get; }
        
        IScene Game { get; }
    }
}