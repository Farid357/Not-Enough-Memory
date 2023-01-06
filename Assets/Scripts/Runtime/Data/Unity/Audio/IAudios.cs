namespace NotEnoughMemory.Audio
{
    public interface IAudios
    {
        IUnityAudio Music { get; }
        
        IUnityAudio TelephonePress { get; }
    }
}