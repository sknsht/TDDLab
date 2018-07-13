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
    public class InvoiceLineTest
    {
        InvoiceLine validInvoiceLine;
        InvoiceLine withoutProduct;
        InvoiceLine withoutMoney;

        [SetUp]
        public void SetUp()
        {
            validInvoiceLine = new InvoiceLine("testProduct", new Money(42, "PLN"));
            withoutProduct   = new InvoiceLine("", new Money(42, "PLN"));
            withoutMoney     = new InvoiceLine("testProduct", null);
        }

        [Test]
        public void InvoiceLineShouldBeValid()
        {
            Assert.IsTrue(validInvoiceLine.IsValid);
        }

        [Test]
        public void InvoiceLineWithoutProductShouldNotBeValid()
        {
            Assert.IsFalse(withoutProduct.IsValid);
        }

        [Test]
        public void InvoiceLineWithoutMoneyShouldNotBeValid() {
            Assert.IsFalse(withoutMoney.IsValid);
        }

        [TearDown]
        public void TearDown()
        {
            validInvoiceLine = null;
            withoutProduct   = null;
            withoutProduct   = null;
        }
    }
}
