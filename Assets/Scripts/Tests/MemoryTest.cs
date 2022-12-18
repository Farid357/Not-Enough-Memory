using NotEnoughMemory.Model;
using NUnit.Framework;

namespace NotEnoughMemory.Tests
{
    public sealed class MemoryTest
    {
        [Test]
        public void FillsCorrectly()
        {
            IMemory memory = new Memory(new DummyMemoryView(), new DummyTelephoneView(readyToSwitchAppearance: false));
            memory.Fill(1);
            Assert.That(memory.Amount == 1);
        }
    }
}