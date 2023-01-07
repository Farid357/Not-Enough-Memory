using NotEnoughMemory.Audio;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyAudios : IAudios
    {
        public IGameEngineAudio Music => new DummyUnityAudio();
        
        public IGameEngineAudio TelephonePress => new DummyUnityAudio();
    }
}