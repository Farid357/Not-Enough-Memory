namespace NotEnoughMemory.Game.Loop
{
    public interface IGameEngineLoop
    {
        void Add(IGameLoop gameLoop, IGameTime gameTime);
    }
}