using System;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.UI
{
    public sealed class TelephoneClickAction : IButtonClickAction
    {
        private readonly ITelephoneBreaker _telephoneBreaker;
        private readonly ITelephone _telephone;
        private readonly ITelephoneClickEffect _telephoneClickEffect;

        public TelephoneClickAction(ITelephone telephone, ITelephoneClickEffect telephoneClickEffect)
        {
            _telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
            _telephoneClickEffect =
                telephoneClickEffect ?? throw new ArgumentNullException(nameof(telephoneClickEffect));
            _telephoneBreaker = new TelephoneBreaker();
        }

        public void OnClick()
        {
            _telephoneClickEffect.Play();
            var memory = _telephone.Memory;

            if (_telephone.IsBroken)
            {
                if (memory.CanClear(1))
                    memory.Clear(1);
            }

            else
            {
                memory.Fill(1);
                _telephoneBreaker.TryBreak(_telephone);
            }
        }
    }
}