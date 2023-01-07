namespace NotEnoughMemory.Game.Loop
{
    public interface IGameLoop : IUpdateable, ILateUpdateable, IFixedUpdateable
    {
        ILateGameUpdate LateGameUpdate { get; }
        
        IFixedGameUpdate FixedGameUpdate { get; }
        
        IGameUpdate GameUpdate { get; }
    }
}