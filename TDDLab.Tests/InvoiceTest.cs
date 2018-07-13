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
    public class InvoiceTest
    {
        Invoice notValidInvoice;

        [SetUp]
        public void SetUp()
        {
            notValidInvoice = new Invoice();
        }

        [Test]
        public void InvoiceShouldNotBeValid()
        {
            Assert.IsFalse(notValidInvoice.IsValid);
        }

        [TearDown]
        public void TearDown()
        {
            notValidInvoice = null;
        }
    }
}
