namespace NotEnoughMemory.Audio
{
    public interface IAudios
    {
        IGameEngineAudio Music { get; }
        
        IGameEngineAudio TelephonePress { get; }
    }
}