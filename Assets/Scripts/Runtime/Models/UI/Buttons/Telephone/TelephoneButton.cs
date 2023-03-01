using System;
using NotEnoughMemory.Model;

namespace NotEnoughMemory.UI
{
    public sealed class TelephoneButton : IButton
    {
        private readonly IWallet _wallet;
        private readonly IRandom _telephoneBrakeRandom;
        private readonly Money _addingMoney = new(1);

        public TelephoneButton(ITelephone telephone, IWallet wallet, IRandom telephoneBrakeRandom)
        {
            Telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _telephoneBrakeRandom = telephoneBrakeRandom ?? throw new ArgumentNullException(nameof(telephoneBrakeRandom));
        }

        public ITelephone Telephone { get; }

        public void Press()
        {
            IMemory memory = Telephone.Memory;

            if (Telephone.IsBroken)
            {
                if (memory.CanClear(1))
                    memory.Clear(1);
            }

            else
            {
                _wallet.Put(_addingMoney);
                memory.Fill(1);

                if (_telephoneBrakeRandom.TryLuck())
                    Telephone.Break();
            }
        }
    }
}