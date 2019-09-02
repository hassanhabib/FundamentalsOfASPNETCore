using ABC.Brokers;
using ABC.Models;
using ABC.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XYZ;
using XYZ.Models;

namespace ABCTests
{
    public class XYZServiceTests
    {
        [Fact]
        public void ShouldCallXYZBrokerToSendNotification()
        {
            // given
            var xyzBrokerMock = new Mock<IXYZBroker>();
            Guid notificationId = Guid.NewGuid();
            Guid notificationResponseId = Guid.NewGuid();

            var notification = new Notification
            {
                Id = notificationId
            };

            var notificationResponse = new NotificationResponse
            {
                Id = notificationResponseId
            };

            var expectedNotification = new ABCNotification
            {
                Id = notificationId
            };

            var expectedNotificationResponse = new ABCNotificationResponse
            {
                Id = notificationResponseId
            };

            xyzBrokerMock.Setup(broker =>
                broker.SendNotification(
                    It.Is<Notification>(notification => notification.Id == notificationId)))
                .Returns(notificationResponse);

            // when
            var xyzService = new XYZService(xyzBrokerMock.Object);
            ABCNotificationResponse actualResponse = xyzService.SendNotification(expectedNotification);

            // then
            actualResponse.Should().BeEquivalentTo(expectedNotificationResponse);
        }
    }
}
