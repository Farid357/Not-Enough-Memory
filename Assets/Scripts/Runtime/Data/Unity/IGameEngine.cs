using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using NotEnoughMemory.SceneLoading;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public interface IGameEngine
    {
        IViews Views { get; }
        
        IUI UI { get; }
        
        IScenes Scenes { get; }
        
        ISceneLoader SceneLoader { get; }
        
    }
}