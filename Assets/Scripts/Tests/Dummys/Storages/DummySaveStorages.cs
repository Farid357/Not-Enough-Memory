using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;

namespace NotEnoughMemory.Tests
{
    public sealed class DummySaveStorages : ISaveStorages
    {
        public DummySaveStorages(ISaveStorage<Money> money)
        {
            Money = money ?? throw new ArgumentNullException(nameof(money));
        }

        public ISaveStorage<Money> Money { get; }

        public void Compose(IWallet wallet)
        {
            
        }

        public void DeleteAllSaves()
        {
            
        }
    }
}