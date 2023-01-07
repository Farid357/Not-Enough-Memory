namespace NotEnoughMemory.UI
{
    public interface IGameEngineButtons
    {
        IGameEngineButton Telephone { get; }
        
        IGameEngineButton DeleteAllSaves { get; }
        
        IGameEngineButton Music { get; }

        IGameEngineButton Exit { get; }
        
        IGameEngineButton CloseExitWindow { get; }
        
        IGameEngineButton Play { get; }
    }
}