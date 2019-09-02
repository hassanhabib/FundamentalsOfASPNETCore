using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ;
using XYZ.Models;

namespace ABC.Brokers
{
    public interface IXYZBroker
    {
        NotificationResponse SendNotification(Notification notification);
    }
}
