using System;
using NotEnoughMemory.Game.Loop;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Factories
{
    public sealed class WalletFactory : IFactory<IWallet>
    {
        private readonly ITextView _moneyTextView;
        private readonly ILateGameUpdate _lateGameUpdate;
        private readonly ISaveStorages _saveStorages;

        public WalletFactory(ITextView moneyTextView, ILateGameUpdate lateGameUpdate, ISaveStorages saveStorages)
        {
            _moneyTextView = moneyTextView ?? throw new ArgumentNullException(nameof(moneyTextView));
            _lateGameUpdate = lateGameUpdate ?? throw new ArgumentNullException(nameof(lateGameUpdate));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public IWallet Create()
        {
            ISaveStorage<Money> storage = new BinaryStorage<Money>(new PathWithNames<IWallet, IFactory<IWallet>>());
            IWallet wallet = new Wallet(_moneyTextView, storage);
            _lateGameUpdate.Add(wallet);
            _saveStorages.Add(storage);
            return wallet;
        }
    }
}