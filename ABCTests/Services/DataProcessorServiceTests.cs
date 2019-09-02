using ABC.Brokers;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Tynamix.ObjectFiller;
using System.Linq;
using ABC.Services;
using FluentAssertions;

namespace ABCTests
{
    public class DataProcessorServiceTests
    {
        [Fact]
        public void ShouldConvertRetrievedDataToUppercase()
        {
            // given
            var storageBrokerMock = new Mock<IStorageBroker>();
            var returnedDataFiller =
                new Filler<string>();
            List<string> returnedData =
                returnedDataFiller.Create(10).ToList();

            List<string> expectedResult =
                returnedData.Select(item => item.ToUpper())
                .ToList();

            storageBrokerMock.Setup(broker => broker.GetAllData())
                .Returns(returnedData);

            // when
            var dataProcessorService =
                new DataProcessorService(storageBrokerMock.Object);

            List<string> actualResult = dataProcessorService.ProcessData();

            // then
            storageBrokerMock.Verify(broker =>
                broker.GetAllData(),
                Times.Once,
                "Storage broker should be called at least once for data processing.");

            actualResult.Should().BeEquivalentTo(
                expectedResult, 
                because: "Returned lists should be both uppercase.");
        }
    }
}
