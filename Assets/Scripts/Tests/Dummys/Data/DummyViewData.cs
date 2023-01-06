using NotEnoughMemory.Model;
using NotEnoughMemory.Tests.Dummys;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Tests
{
    public sealed class DummyViewData : IViewData
    {
        public ITelephonePressEffect TelephonePressEffect => new DummyTelephonePressEffect()

        public ITelephoneView Telephone => new DummyTelephoneView(readyToSwitchAppearance: Factories);
        
        public IMemoryView Memory => new DummyMemoryView();
    }
}