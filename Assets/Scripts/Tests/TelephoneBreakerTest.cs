using NotEnoughMemory.Model;
using NotEnoughMemory.Tests.Dummys;
using NUnit.Framework;

namespace NotEnoughMemory.Tests
{
    [TestFixture]
    public sealed class TelephoneBreakerTest
    {
        [Test]
        public void BrakesCorrectly()
        {
            ITelephone telephone = new Telephone(new DummyTelephoneView(false), new DummyMemory(), new DummyMemoryView());
            ITelephoneBreaker telephoneBreaker = new TelephoneBreaker( new Random(new DummyChance(isLucky: false)));
            Assert.That(telephoneBreaker.TryBreak(telephone) == false);
        }

    }
}