namespace NotEnoughMemory.Game.Loop
{
    public interface IGameEngineLoopUpdate
    {
        void Update(IGameLoop gameLoop, IGameTime gameTime);
    }
}