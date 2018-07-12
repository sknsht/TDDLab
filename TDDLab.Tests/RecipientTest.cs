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
    public class RecipientTest
    {
        Recipient validRecipient;
        Recipient withoutName;
        Recipient withoutAddress;

        [SetUp]
        public void SetUp()
        {
            validRecipient = new Recipient("Maciej", new Address("Grunwaldzka 190", "Gdańsk", "Pomorskie", "80-266"));
            withoutName    = new Recipient("", new Address("Grunwaldzka 190", "Gdańsk", "Pomorskie", "80-266"));
            withoutAddress = new Recipient("Maciej", null);
        }

        [Test]
        public void invoiceLineShouldBeValid()
        {
            Assert.IsTrue(validRecipient.IsValid);
        }

        [Test]
        public void invoiceLineShouldNotBeValid()
        {
            Assert.IsFalse(withoutName.IsValid);
            //Assert.IsFalse(withoutAddress.IsValid);
        }

        [TearDown]
        public void TearDown()
        {
            validRecipient = null;
            withoutName    = null;
            withoutAddress = null;
        }
    }
}
