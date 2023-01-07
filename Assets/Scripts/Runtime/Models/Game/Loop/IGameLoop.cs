namespace NotEnoughMemory.Game.Loop
{
    public interface IGameLoop : IUpdateble, ILateUpdateble, IFixedUpdateble
    {
        ILateGameUpdate LateGameUpdate { get; }
        
        IFixedGameUpdate FixedGameUpdate { get; }
        
        IGameUpdate GameUpdate { get; }
    }
}