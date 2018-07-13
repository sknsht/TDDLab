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
    public class AddressTest
    {
        Address validAddress;
        Address withoutAddressLine;
        Address withoutCity;
        Address withoutState;
        Address withoutZip;

        [SetUp]
        public void SetUp()
        {
            validAddress       = new Address("Grunwaldzka 190", "Gdańsk", "Pomorskie", "80-266");
            withoutAddressLine = new Address("", "Gdańsk", "Pomorskie", "80-266");
            withoutCity        = new Address("Grunwaldzka 190", "", "Pomorskie", "80-266");
            withoutState       = new Address("Grunwaldzka 190", "Gdańsk", "", "80-266");
            withoutZip         = new Address("Grunwaldzka 190", "Gdańsk", "Pomorskie", "");
        }

        [Test]
        public void AddressShouldBeValid()
        {
            Assert.IsTrue(validAddress.IsValid);
        }

        [Test]
        public void AddressWithoutAddressLineShouldNotBeValid()
        {
            Assert.IsFalse(withoutAddressLine.IsValid);
        }

        [Test]
        public void AddressWithoutCityShouldNotBeValid() {
            Assert.IsFalse(withoutCity.IsValid);
        }

        [Test]
        public void AddressWithoutStateShouldNotBeValid() {
            Assert.IsFalse(withoutState.IsValid);
        }

        [Test]
        public void AddressWithoutZipShouldNotBeValid() {
            Assert.IsFalse(withoutZip.IsValid);
        }

        [TearDown]
        public void TearDown()
        {
            validAddress       = null;
            withoutAddressLine = null;
            withoutCity        = null;
            withoutState       = null;
            withoutZip         = null;
        }
    }
}
