using NotEnoughMemory.Factories;
using NotEnoughMemory.Model;
using NotEnoughMemory.Tests.Dummys;
using NUnit.Framework;

namespace NotEnoughMemory.Tests
{
    [TestFixture]
    public sealed class TelephoneFactoryTest
    {
        [Test]
        public void CreatesCorrectly()
        {
            ITelephoneView telephoneView = new DummyTelephoneView(readyToSwitchAppearance: false);
            IMemory memory = new DummyMemory();
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(telephoneView, new DummyMemoryView(), memory);
            var createdTelephone = telephoneFactory.Create();
            Assert.That(createdTelephone.Memory == memory);
        }
        
    }
}