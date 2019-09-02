using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.Brokers;
using ABC.Models;
using XYZ;
using XYZ.Models;

namespace ABC.Services
{
    public class XYZService : IXYZService
    {
        private readonly IXYZBroker xYZBroker;

        public XYZService(IXYZBroker xYZBroker)
        {
            this.xYZBroker = xYZBroker;
        }

        public ABCNotificationResponse SendNotification(ABCNotification notification)
        {
            Notification notificationV1 = MapToXYZNotification(notification);
            NotificationResponse notificationResponse = 
                this.xYZBroker.SendNotification(notificationV1);

            return MapToABCNotificationResponse(notificationResponse);
        }

        private ABCNotificationResponse MapToABCNotificationResponse(
            NotificationResponse notificationResponseV2)
        {
            return new ABCNotificationResponse
            {
                Id = notificationResponseV2.Id
            };
        }

        private Notification MapToXYZNotification(ABCNotification aBCNotification)
        {
            return new Notification
            {
                Id = aBCNotification.Id
            };
        }
    }
}
