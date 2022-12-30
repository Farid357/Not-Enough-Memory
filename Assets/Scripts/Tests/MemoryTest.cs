using NotEnoughMemory.Model;
using NUnit.Framework;

namespace NotEnoughMemory.Tests
{
    public sealed class MemoryTest
    {
        [Test]
        public void FillsCorrectly()
        {
            IMemory memory = new Memory();
            memory.Fill(1);
            Assert.That(memory.Amount == 1);
        }

        [Test]
        public void CleansCorrectly()
        {
            IMemory memory = new Memory();
            memory.Fill(1);
            memory.Clear();
            Assert.That(memory.Amount == 0);
        }

        [Test]
        public void BrakesCorrectly()
        {
            IMemory memory = new Memory();
            memory.Break();
            Assert.That(memory.IsBroken);
        }
    }
}