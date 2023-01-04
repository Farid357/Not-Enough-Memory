using System;
using NotEnoughMemory.View;

namespace NotEnoughMemory.Model
{
    public sealed class Wallet : IWallet
    {
        private readonly ITextView _textView;

        public Wallet(ITextView textView, Money startMoney)
        {
            _textView = textView ?? throw new ArgumentNullException(nameof(textView));
            Money = startMoney;
        }

        public Money Money { get; private set; }
        
        public bool HasMoneyChanged { get; private set; }

        public void Put(Money money)
        {
            Money += money;
            HasMoneyChanged = true;
            _textView.Visualize(Money);
        }

        public void Take(Money money)
        {
            Money -= money;
            HasMoneyChanged = true;
            _textView.Visualize(Money);
        }

        public void LateUpdate()
        {
            HasMoneyChanged = false;
        }
    }
}