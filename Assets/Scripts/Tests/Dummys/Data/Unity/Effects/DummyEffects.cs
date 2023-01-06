using NotEnoughMemory.Model;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyEffects : IEffects
    {
        public ITelephonePressEffect TelephonePress => new DummyTelephonePressEffect();
        
        
    }
}