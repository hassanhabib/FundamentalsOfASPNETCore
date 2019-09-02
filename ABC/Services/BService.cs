using ABC.Brokers;
using ABC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class BService : IBService
    {
        private readonly IXYZService xYZService;

        public BService(IXYZService xYZService)
        {
            this.xYZService = xYZService;
        }

        public void DoStuffB(ABCNotification notification)
        {
            this.xYZService.SendNotification(notification);
        }
    }
}
