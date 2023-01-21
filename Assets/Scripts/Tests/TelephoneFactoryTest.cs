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
            IGameEngine gameEngine = new Game.Unity(new DummyViews(), new DummyUI(), new DummyScenes(), new DummySceneLoader());
            IFactory<ITelephone> telephoneFactory = new TelephoneFactory(new Game.Loop.GameLoop(new UnscaledGameTime()), gameEngine, new DummyWallet());
            ITelephone createdTelephone = telephoneFactory.Create();
            Assert.That(createdTelephone.Memory == memory);
        }
    }
}