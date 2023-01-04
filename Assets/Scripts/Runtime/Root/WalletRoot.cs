using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Root
{
    public sealed class WalletRoot
    {
        private readonly ITextView _moneyTextView;
        private readonly ISaveStorages _saveStorages;

        public WalletRoot(ITextView moneyTextView, ISaveStorages saveStorages)
        {
            _moneyTextView = moneyTextView ?? throw new ArgumentNullException(nameof(moneyTextView));
            _saveStorages = saveStorages ?? throw new ArgumentNullException(nameof(saveStorages));
        }

        public IWallet Compose()
        {
            var startMoney = _saveStorages.Money.HasSave() ? _saveStorages.Money.Load() : new Money(1);
            return new Wallet(_moneyTextView, startMoney);
        }
    }
}