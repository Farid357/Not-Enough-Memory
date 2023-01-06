using NotEnoughMemory.Model;

namespace NotEnoughMemory.View
{
    public interface IEffects
    {
        ITelephonePressEffect TelephonePress { get; }
    }
}