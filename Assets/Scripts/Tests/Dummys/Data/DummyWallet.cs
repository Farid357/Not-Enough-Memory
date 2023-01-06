using NotEnoughMemory.Model;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyWallet : IWallet
    {
        public Money Money => new(1);

        public bool HasMoneyChanged => false;
        
        public void LateUpdate()
        {
            
        }
        
        public void Take(Money money)
        {
        }

        public void Put(Money money)
        {
        }
    }
}