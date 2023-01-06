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
            IMemory memory = new DummyMemory();
            var gameData = new Game.Unity(new DummyView(), new DummyIui(), new DummyScenes(), new DummyAudioData());
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(new Game.Loop.GameLoop(),gameData, new DummyWallet());
            var createdTelephone = telephoneFactory.Create();
            Assert.That(createdTelephone.Memory == memory);
        }
        
    }
}