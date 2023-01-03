using NotEnoughMemory.GameLoop;

namespace NotEnoughMemory.Root
{
    public interface IGameUpdate
    {
        ILateSystemUpdate LateSystemUpdate { get; }
        
        IFixedSystemUpdate FixedSystemUpdate { get; }
        
        ISystemUpdate SystemUpdate { get; }
    }
}