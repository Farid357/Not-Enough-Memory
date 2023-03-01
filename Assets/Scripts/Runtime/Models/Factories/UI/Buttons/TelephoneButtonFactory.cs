using System;
using NotEnoughMemory.Audio;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;
using NotEnoughMemory.View;
using Random = NotEnoughMemory.Model.Random;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneButtonFactory : IFactory<IButton>
    {
        private readonly IEffect _telephonePressEffect;
        private readonly IWallet _wallet;
        private readonly ITelephone _telephone;
        private readonly IAudio _telephonePressAudio;

        public TelephoneButtonFactory(IEffect telephonePressEffect, IWallet wallet, ITelephone telephone, IAudio telephonePressAudio)
        {
            _telephonePressEffect = telephonePressEffect ?? throw new ArgumentNullException(nameof(telephonePressEffect));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
            _telephonePressAudio = telephonePressAudio ?? throw new ArgumentNullException(nameof(telephonePressAudio));
        }

        public IButton Create()
        {
            var buttons = new Buttons(new AudioPlayButton(_telephonePressAudio), new EffectPlayButton(_telephonePressEffect));
            return new Buttons(new TelephoneButton(_telephone, _wallet, new Random(new OneQuarterChance())), buttons);
        }
    }
}