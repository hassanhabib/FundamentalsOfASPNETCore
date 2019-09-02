using ABC.Brokers;
using ABC.Models;
using ABC.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Tynamix.ObjectFiller;
using Xunit;

namespace ABCTests.Services
{
    public class AServiceTests
    {
        [Fact]
        public void ShouldCallXyzServiceToSendNotification()
        {
            // given
            var xyzServiceMock = new Mock<IXYZService>();
            ABCNotification notification = new Filler<ABCNotification>().Create();

            ABCNotificationResponse notificationResponse =
                new Filler<ABCNotificationResponse>().Create();

            xyzServiceMock.Setup(broker => broker.SendNotification(notification))
                .Returns(notificationResponse);

            // when
            var aService = new AService(xyzServiceMock.Object);
            aService.DoStuffA(notification);

            // then
            xyzServiceMock.Verify(
                broker => broker.SendNotification(notification),
                Times.Once);
        }
    }
}
