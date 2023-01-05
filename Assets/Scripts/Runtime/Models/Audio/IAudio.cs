namespace NotEnoughMemory.Audio
{
    public interface IAudio
    {
        bool IsPlaying { get; }

        void Play();

        void Stop();
    }
}