using NotEnoughMemory.Model;
using NotEnoughMemory.Tests.Dummys;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Tests
{
    public sealed class DummyView : IView
    {
        public ITelephonePressEffect TelephonePressEffect => new DummyTelephonePressEffect();

        public ITelephoneView Telephone => new DummyTelephoneView(readyToSwitchAppearance: false);
        
        public IMemoryView Memory => new DummyMemoryView();
    }
}