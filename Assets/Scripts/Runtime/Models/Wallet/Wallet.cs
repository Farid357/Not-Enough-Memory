using System;
using NotEnoughMemory.Storage;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Model
{
    public sealed class Wallet : IWallet
    {
        private readonly ITextView _textView;
        private readonly ISaveStorage<Money> _storage;

        public Wallet(ITextView textView, ISaveStorage<Money> storage)
        {
            _textView = textView ?? throw new ArgumentNullException(nameof(textView));
            _storage = storage;
            Money = _storage.HasSave() ? _storage.Load() : new Money(10);
            _textView.Visualize(Money);
        }

        public Money Money { get; private set; }
        
        public void Put(Money money)
        {
            Money += money;
            VisualizeAndSave(Money);
        }

        public void Take(Money money)
        {
            Money -= money;
            VisualizeAndSave(Money);
        }

        private void VisualizeAndSave(Money money)
        {
            _textView.Visualize(money);
            _storage.Save(money);
        }
    }
}