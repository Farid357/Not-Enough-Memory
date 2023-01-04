namespace NotEnoughMemory.GameLoop
{
    public interface IGameLoop
    {
        ILateGameUpdate LateGameUpdate { get; }
        
        IFixedGameUpdate FixedGameUpdate { get; }
        
        IGameUpdate GameUpdate { get; }

        void Update(float deltaTime);

        void FixedUpdate(float fixedDeltaTime);

        void LateUpdate();
    }
}