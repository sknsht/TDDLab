﻿using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests {
    [TestFixture]
    public class RecipientTest {
        Recipient validRecipient;
        Recipient withoutName;

        [SetUp]
        public void SetUp() {
            validRecipient = new Recipient("Maciej", new Address("Grunwaldzka 190", "Gdańsk", "Pomorskie", "80-266"));
            withoutName    = new Recipient("", new Address("Grunwaldzka 190", "Gdańsk", "Pomorskie", "80-266"));
        }

        [Test]
        public void InvoiceLineShouldBeValid() {
            Assert.IsTrue(validRecipient.IsValid);
        }

        [Test]
        public void InvoiceLineWithoutNameShouldNotBeValid() {
            Assert.IsFalse(withoutName.IsValid);
        }

        [TearDown]
        public void TearDown() {
            validRecipient = null;
            withoutName    = null;
        }
    }
}
