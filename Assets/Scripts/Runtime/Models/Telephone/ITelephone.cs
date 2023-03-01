using NotEnoughMemory.Game.Loop;

namespace NotEnoughMemory.Model
{
    public interface ITelephone : IGameLoopObject
    {
        bool IsBroken { get; }
        
        IMemory Memory { get; }
        
        void Break();
        
        void Fix();
    }
}