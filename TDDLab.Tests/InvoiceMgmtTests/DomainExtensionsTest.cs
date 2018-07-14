using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests {
    [TestFixture]
    public class DomainExtensionsTest {
        Money money;
        Money newMoney;

        [SetUp]
        public void SetUp() {
            money = new Money(42);
            newMoney = money.ToCurrency("PLN");
        }

        [Test]
        public void ToCurrencyAmountShouldBeEqual() {
            Assert.AreEqual(newMoney.Amount, money.Amount);
        }

        [TearDown]
        public void TearDown() {
            money = null;
            newMoney = null;
        }
    }
}
