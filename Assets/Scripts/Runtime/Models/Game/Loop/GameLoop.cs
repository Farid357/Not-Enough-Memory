namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameLoop : IUpdateable, IFixedUpdateable, ILateUpdateable, IGameLoop
    {
        private readonly LateGameUpdate _lateGameUpdate = new();
        private readonly FixedGameUpdate _fixedGameUpdate = new();
        private readonly GameUpdate _gameUpdate = new();

        public ILateGameUpdate LateGameUpdate => _lateGameUpdate;

        public IFixedGameUpdate FixedGameUpdate => _fixedGameUpdate;

        public IGameUpdate GameUpdate => _gameUpdate;

        public void Update(float deltaTime)
        {
            _gameUpdate.Update(deltaTime);
        }

        public void FixedUpdate(float fixedDeltaTime)
        {
            _fixedGameUpdate.FixedUpdate(fixedDeltaTime);
        }

        public void LateUpdate()
        {
            _lateGameUpdate.LateUpdate();
        }
    }
}