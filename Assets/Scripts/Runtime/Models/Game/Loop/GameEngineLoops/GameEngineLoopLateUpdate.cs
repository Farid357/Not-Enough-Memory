namespace NotEnoughMemory.Game.Loop
{
    public sealed class GameEngineLoopLateUpdate : IGameEngineLoopUpdate
    {
        public void Update(IGameLoop gameLoop, IGameTime gameTime)
        {
            gameLoop.LateUpdate();
        }
    }
}