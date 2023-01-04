using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.UI;

namespace NotEnoughMemory.Factories
{
    public sealed class TelephoneButtonFactory : IFactory<ITelephoneButton>
    {
        private readonly ITelephoneClickEffect _telephoneClickEffect;
        private readonly IWallet _wallet;
        private readonly ITelephone _telephone;

        public TelephoneButtonFactory(ITelephoneClickEffect telephoneClickEffect, IWallet wallet, ITelephone telephone)
        {
            _telephoneClickEffect = telephoneClickEffect ?? throw new ArgumentNullException(nameof(telephoneClickEffect));
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _telephone = telephone ?? throw new ArgumentNullException(nameof(telephone));
        }

        public ITelephoneButton Create()
        {
            return new TelephoneButton(_telephone, _telephoneClickEffect, _wallet);
        }
    }
}