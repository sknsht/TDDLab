using NUnit.Framework;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests {

    [TestFixture]
    public class InvoiceProcessorImplTest {
        Invoice invoice;
        InvoiceProcessorImpl invoiceProcessor;

        [SetUp]
        public void SetUp() {
            invoice = new Invoice();
            invoiceProcessor = new InvoiceProcessorImpl();
        }

        [Test]
        public void processingResultShouldBeFail() {
            Assert.AreEqual(invoiceProcessor.Process(invoice), ProcessingResult.Failed());
        }
    }
}
