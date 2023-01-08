using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Game
{
    public interface IGameEngine
    {
        IViews Views { get; }
        
        IUI UI { get; }
        
        IScenes Scenes { get; }
        
        IGameEngineLoop Loop { get; }
        
    }
}