using NotEnoughMemory.Audio;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyUnityAudio : IGameEngineAudio
    {
        public bool IsPlaying { get; }
        
        public void Play()
        {
            
        }

        public void Stop()
        {
        }

        public void PlayOneShot()
        {
        }
    }
}