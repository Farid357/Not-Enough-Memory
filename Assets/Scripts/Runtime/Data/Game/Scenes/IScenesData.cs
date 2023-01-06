using NotEnoughMemory.SceneLoading;

namespace NotEnoughMemory.Model
{
    public interface IScenesData
    {
        IScene Menu { get; }
        
        IScene Game { get; }
    }
}