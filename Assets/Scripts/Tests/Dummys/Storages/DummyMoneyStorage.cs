using System;
using NotEnoughMemory.Model;
using NotEnoughMemory.Storage;

namespace NotEnoughMemory.Tests
{
    public sealed class DummyMoneyStorage : ISaveStorage<Money>
    {
        private readonly Money _money;

        public DummyMoneyStorage(Money money)
        {
            _money = money ?? throw new ArgumentNullException(nameof(money));
        }

        public bool HasSave() => true;

        public void DeleteSave()
        {
           
        }

        public Money Load()
        {
            return _money;
        }

        public void Save(Money money)
        {
            
        }
    }
}