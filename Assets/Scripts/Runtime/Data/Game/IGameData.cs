using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using NotEnoughMemory.Root;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Game
{
    public interface IGameData
    {
        IViewData View { get; }
        
        IUIData UI { get; }
        
        IScenesData Scenes { get; }
        
        IAudioData Audio { get; }
        
    }
}