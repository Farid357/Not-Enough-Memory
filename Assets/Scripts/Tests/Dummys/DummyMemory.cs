using NotEnoughMemory.Model;

namespace NotEnoughMemory.Tests.Dummys
{
    public sealed class DummyMemory : IMemory
    {
        public int Amount { get; }
        
        public bool HasAmountChanged { get; }
        
        public bool IsBroken { get; }
        
        public bool CanClear(int amount) => false;

        public void Clear()
        {
        }

        public void Clear(int amount)
        {
        }

        public void Break()
        {
        }

        public void Fix()
        {
        }

        public void Fill(int amount)
        {
        }

        public void LateUpdate()
        {
            
        }
    }
}