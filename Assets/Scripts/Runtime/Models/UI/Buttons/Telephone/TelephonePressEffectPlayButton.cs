using System;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.UI
{
    public sealed class TelephonePressEffectPlayButton : IButton
    {
        private readonly ITelephonePressEffect _effect;

        public TelephonePressEffectPlayButton(ITelephonePressEffect effect)
        {
            _effect = effect ?? throw new ArgumentNullException(nameof(effect));
        }

        public void Press()
        {
            _effect.Play();
        }
    }
}