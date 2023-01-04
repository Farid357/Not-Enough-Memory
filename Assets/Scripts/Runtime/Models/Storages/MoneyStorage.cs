using System;
using NotEnoughMemory.GameLoop;
using NotEnoughMemory.Storage;

namespace NotEnoughMemory.Model
{
    public sealed class MoneyStorage : IUpdateable
    {
        private readonly IWallet _wallet;
        private readonly ISaveStorage<Money> _storage;

        public MoneyStorage(IWallet wallet, ISaveStorage<Money> storage)
        {
            _wallet = wallet ?? throw new ArgumentNullException(nameof(wallet));
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public void Update(float deltaTime)
        {
            if (_wallet.HasMoneyChanged)
            {
                _storage.Save(_wallet.Money);
            }
        }
    }
}