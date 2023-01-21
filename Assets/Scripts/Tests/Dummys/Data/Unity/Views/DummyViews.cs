using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyViews : IViews
    {
        public IViewsFactories Factories { get; }
        
        public IEffects Effects => new DummyEffects();

        public IAudios Audios => new DummyAudios();
        
        public ITelephoneView Telephone => new DummyTelephoneView(readyToSwitchAppearance: false);
        
        public IMemoryView Memory => new DummyMemoryView();
    }
}