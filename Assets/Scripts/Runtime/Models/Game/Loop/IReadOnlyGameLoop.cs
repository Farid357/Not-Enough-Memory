namespace NotEnoughMemory.Game.Loop
{
    public interface IReadOnlyGameLoop
    {
        ILateGameUpdate LateGameUpdate { get; }
        
        IFixedGameUpdate FixedGameUpdate { get; }
        
        IGameUpdate GameUpdate { get; }
    }
}