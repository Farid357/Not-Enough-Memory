using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Factories
{
    public sealed class WalletFactory : IFactory<IWallet>
    {
        private readonly ITextView _moneyTextView;
        private readonly ISaveStorages _saveStorages;

        public WalletFactory(ITextView moneyTextView, ISaveStorages saveStorages)
        {
            _moneyTextView = moneyTextView ?? throw new ArgumentNullException(nameof(moneyTextView));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public IWallet Create()
        {
            ISaveStorage<Money> storage = new BinaryStorage<Money>(new PathWithNames<IWallet, IFactory<IWallet>>());
            IWallet wallet = new Wallet(_moneyTextView, storage);
            _saveStorages.Add(storage);
            return wallet;
        }
    }
}