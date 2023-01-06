using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public interface IUnity
    {
        IView View { get; }
        
        IUI UI { get; }
        
        IScenes Scenes { get; }
        
        IAudioData Audio { get; }
        
    }
}