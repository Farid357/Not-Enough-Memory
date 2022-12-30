using NotEnoughMemory.Model;
using NotEnoughMemory.Tests.Dummys;
using NUnit.Framework;

namespace NotEnoughMemory.Tests
{
    [TestFixture]
    public sealed class MemoryBreakerTest
    {
        [Test]
        public void BrakesCorrectly()
        {
            IMemory memory = new Memory();
            IMemoryBreaker memoryBreaker = new MemoryBreaker(new DummyChance(isLucky: false));
            Assert.That(memoryBreaker.TryBreak(memory) == false);
        }

    }
}