using NotEnoughMemory.Model;
using NUnit.Framework;

namespace NotEnoughMemory.Tests
{
    public sealed class MemoryTest
    {
        private readonly IMemory _memory = new Memory();
        
        [Test]
        public void FillsCorrectly()
        {
            _memory.Fill(1);
            Assert.That(_memory.Amount == 1);
        }

        [Test]
        public void CleansCorrectly()
        {
            _memory.Fill(1);
            _memory.Clear();
            Assert.That(_memory.Amount == 0);
        }
    }
}