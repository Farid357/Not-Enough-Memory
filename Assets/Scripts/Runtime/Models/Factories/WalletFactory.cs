﻿using System;
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
            return new Wallet(_moneyTextView, _saveStorages.Money);
        }
    }
}