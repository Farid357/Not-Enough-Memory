using NotEnoughMemory.Audio;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyAudioData : IAudioData
    {
        public IUnityAudio Music => new DummyUnityAudio();
        
        public IUnityAudio TelephonePress => new DummyUnityAudio();
    }
}