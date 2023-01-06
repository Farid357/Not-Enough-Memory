namespace NotEnoughMemory.Audio
{
    public interface IAudioData
    {
        IUnityAudio Music { get; }
        
        IUnityAudio TelephonePress { get; }
    }
}