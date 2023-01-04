using System;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.UI
{
    public sealed class TelephoneButton : ITelephoneButton
    {
        private readonly ITelephoneBreaker _telephoneBreaker;
        private readonly ITelephoneClickEffect _telephoneClickEffect;
        private readonly IWallet _wallet;
        private readonly Money _addingMoney = new(1);

        public TelephoneButton(ITelephone telephone, ITelephoneClickEffect telephoneClickEffect, IWallet wallet)
        {
            Telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
            _telephoneClickEffect = telephoneClickEffect ?? throw new ArgumentNullException(nameof(telephoneClickEffect));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _telephoneBreaker = new TelephoneBreaker();
        }

        public ITelephone Telephone { get; }

        public void Press()
        {
            _wallet.Put(_addingMoney);
            _telephoneClickEffect.Play();
            var memory = Telephone.Memory;

            if (Telephone.IsBroken)
            {
                if (memory.CanClear(1))
                    memory.Clear(1);
            }

            else
            {
                memory.Fill(1);
                _telephoneBreaker.TryBreak(Telephone);
            }
        }
    }
}