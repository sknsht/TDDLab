using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests {
    [TestFixture]
    public class MoneyTest {
        Money validMoney;
        Money withoutCurrency;

        [SetUp]
        public void SetUp() {
            validMoney      = new Money(42);
            withoutCurrency = new Money(42, null);
        }

        [Test]
        public void DefaultCurrencyTest() {
            Assert.AreEqual(validMoney.Currency, "USD");
        }

        [Test]
        public void MoneyToStringTest() {
            Assert.AreEqual(validMoney.ToString(), "42USD");
        }

        [Test]
        public void MoneyWithoutCurrencyShouldNotBeValid() {
            Assert.IsFalse(withoutCurrency.IsValid);
        }

        [Test]
        public void MoneyAddTest() {
            Assert.AreEqual((validMoney + validMoney).Amount, validMoney.Amount * 2);
        }

        [Test]
        public void MoneyReduceTest() {
            Assert.AreEqual((validMoney - validMoney).Amount, 0);
        }

        [TearDown]
        public void TearDown() {
            validMoney      = null;
            withoutCurrency = null;
        }
    }
}
