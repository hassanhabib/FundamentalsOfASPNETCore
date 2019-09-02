using System;
using XYZ;
using XYZ.Models;

namespace ABC.Brokers
{
    public class XYZBroker : IXYZBroker
    {
        private readonly NotificationsService notificationsService;
        public XYZBroker()
        {
            this.notificationsService = new NotificationsService();
        }

        public NotificationResponse SendNotification(Notification notification)
        {
            return this.notificationsService.SendNotification(notification);
        }
    }
}
