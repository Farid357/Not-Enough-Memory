using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.View;

namespace NotEnoughMemory.UI
{
    public sealed class EffectPlayButton : IButton
    {
        private readonly IEffect _effect;
        private readonly ITransformData _playingTransform;

        public EffectPlayButton(IEffect effect)
        {
            _effect = effect ?? throw new ArgumentNullException(nameof(effect));
        }
        
        public EffectPlayButton(IEffect effect, ITransformData playingTransform) : this(effect)
        {
            _playingTransform = playingTransform ?? throw new ArgumentNullException(nameof(playingTransform));
        }

        public void Press()
        {
            if (_playingTransform == null)
            {
                _effect.Play();
            }
            
            else
            {
                _effect.PlayIn(_playingTransform);
            }
        }
    }
}