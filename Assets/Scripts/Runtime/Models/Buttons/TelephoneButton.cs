using System;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.UI
{
    public sealed class TelephoneButton : ITelephoneButton
    {
        private readonly ITelephoneBreaker _telephoneBreaker;
        private readonly IButton _button;
        private readonly IWallet _wallet;
        private readonly Money _addingMoney = new(1);

        public TelephoneButton(ITelephone telephone, IButton button, IWallet wallet)
        {
            Telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _telephoneBreaker = new TelephoneBreaker();
        }

        public ITelephone Telephone { get; }

        public void Press()
        {
            _button.Press();
            var memory = Telephone.Memory;

            if (Telephone.IsBroken)
            {
                if (memory.CanClear(1))
                    memory.Clear(1);
            }

            else
            {
                _wallet.Put(_addingMoney);
                memory.Fill(1);
                _telephoneBreaker.TryBreak(Telephone);
            }
        }
    }
}