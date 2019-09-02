using ABC.Brokers;
using ABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class AService : IAService
    {
        private readonly IXYZService xYZService;

        public AService(IXYZService xYZService)
        {
            this.xYZService = xYZService;
        }

        public void DoStuffA(ABCNotification notification)
        {
            this.xYZService.SendNotification(notification);
        }
    }
}
