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
    public class DomainExtensionsTest
    {
        Money testMoney;
        Money newMoney;

        [SetUp]
        public void SetUp()
        {
            testMoney = new Money(42);
            newMoney = testMoney.ToCurrency("PLN");
        }

        [Test]
        public void toCurrencyTest()
        {
            Assert.AreEqual(newMoney.Amount, testMoney.Amount);
            Assert.AreEqual(newMoney.Currency, "PLN");
        }

        [TearDown]
        public void TearDown()
        {
            testMoney = null;
            newMoney  = null;
        }
    }
}
