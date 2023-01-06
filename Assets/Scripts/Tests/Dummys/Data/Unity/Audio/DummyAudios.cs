using NotEnoughMemory.Audio;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyAudios : IAudios
    {
        public IUnityAudio Music => new DummyUnityAudio();
        
        public IUnityAudio TelephonePress => new DummyUnityAudio();
    }
}