using NotEnoughMemory.Factories;
using NotEnoughMemory.Game;
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
            var gameData = new GameData(new DummyViewData(), new DummyUIData(), new DummyScenesData(), new DummyAudioData());
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(new Game.Loop.GameLoop(),gameData, new DummyWallet());
            var createdTelephone = telephoneFactory.Create();
            Assert.That(createdTelephone.Memory == memory);
        }
        
    }
}