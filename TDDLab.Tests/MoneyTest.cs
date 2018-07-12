using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests
{
    [TestFixture]
    public class MoneyTest
    {
        Money validMoney;
        Money withoutCurrency;

        [SetUp]
        public void SetUp()
        {
            validMoney      = new Money(42);
            withoutCurrency = new Money(42, null);
        }

        [Test]
        public void defaultCurrencyTest()
        {
            Assert.AreEqual(validMoney.Currency, "USD");
        }

        [Test]
        public void moneyToStringTest()
        {
            Assert.AreEqual(validMoney.ToString(), "42USD");
        }

        [Test]
        public void moneyShouldNotBeValid()
        {
            Assert.IsFalse(withoutCurrency.IsValid);
        }

        [Test]
        public void moneyAddTest()
        {
            Assert.AreEqual((validMoney + validMoney).Amount, validMoney.Amount*2);
        }

        [Test]
        public void moneyReduceTest()
        {
            Assert.AreEqual((validMoney - validMoney).Amount, 0);
            Assert.AreEqual((Money.ZERO - validMoney).Amount, 0);
        }

        [TearDown]
        public void TearDown()
        {
            validMoney      = null;
            withoutCurrency = null;
        }
    }
}
