using NotEnoughMemory.Factories;
using NotEnoughMemory.Model;
using NotEnoughMemory.Tests.Dummys;
using NUnit.Framework;

namespace NotEnoughMemory.Tests
{
    [TestFixture]
    public sealed class WalletFactoryTest
    {
        [Test]
        public void CreatesCorrectlyWithSave()
        {
            var savedMoney = new Money(50);
            IFactory<IWallet> factory = new WalletFactory(new DummyTextView(),
                new DummySaveStorages(new DummyMoneyStorage(savedMoney)));

            var createdWallet = factory.Create();
            Assert.That(createdWallet.Money.Amount == savedMoney.Amount);
        }
    }
}