using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using TDDLab.Core.Infrastructure;
using TDDLab.Core.InvoiceMgmt;

namespace TDDLab.Tests {
    [TestClass]
    public class WorkerImplTest {
        private MockFactory factory = new MockFactory();

        [TestCleanup]
        public void Cleanup() {
            factory.VerifyAllExpectationsHaveBeenMet();
            factory.ClearExpectations();
        }

        [TestMethod]
        public void startShouldInitializeChannelsWithConfigurationSettings() {
            var iConfigurationSettingsMock = factory.CreateMock<IConfigurationSettings>();
            var iMessagingFacilityMock = factory.CreateMock<IMessagingFacility<Invoice, ProcessingResult>>();
            var iExceptionHandlerMock = factory.CreateMock<IExceptionHandler>();
            var iInvoiceProcessorMock = factory.CreateMock<IInvoiceProcessor>();

            var worker = new WorkerImpl
            (
                iConfigurationSettingsMock.MockObject,
                iMessagingFacilityMock.MockObject,
                iExceptionHandlerMock.MockObject,
                iInvoiceProcessorMock.MockObject
            );

            iConfigurationSettingsMock.Expects.One.
                MethodWith(_ => _.GetSettingsByKey("inputQueue")).
                Will(Return.Value("foo"));
            iConfigurationSettingsMock.Expects.One.
                MethodWith(_ => _.GetSettingsByKey("outputQueue")).
                Will(Return.Value("bar"));

            iMessagingFacilityMock.Expects.One.
                MethodWith(_ => _.InitializeInputChannel("foo"));
            iMessagingFacilityMock.Expects.One.
                MethodWith(_ => _.InitializeOutputChannel("bar"));

            worker.Start();
        }

        [TestMethod]
        public void stopShouldDisposeMessagingFacility() {
            var iConfigurationSettingsMock = factory.CreateMock<IConfigurationSettings>();
            var iMessagingFacilityMock = factory.CreateMock<IMessagingFacility<Invoice, ProcessingResult>>();
            var iExceptionHandlerMock = factory.CreateMock<IExceptionHandler>();
            var iInvoiceProcessorMock = factory.CreateMock<IInvoiceProcessor>();

            var worker = new WorkerImpl
            (
                iConfigurationSettingsMock.MockObject,
                iMessagingFacilityMock.MockObject,
                iExceptionHandlerMock.MockObject,
                iInvoiceProcessorMock.MockObject
            );

            iMessagingFacilityMock.Expects.One.
                Method(_ => _.Dispose());

            worker.Stop();
        }

        [TestMethod]
        public void doJobShouldThrowNullReferenceException() {
            var iExceptionHandlerMock = factory.CreateMock<IExceptionHandler>();

            var worker = new WorkerImpl
            (
                null,
                null,
                iExceptionHandlerMock.MockObject,
                null
            );

            iExceptionHandlerMock.Expects.One.
                Method(_ => _.HandleException(null)).
                With(Is.TypeOf<NullReferenceException>());

            worker.DoJob();
        }
    }
}
