using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Brokers
{
    public class StorageBroker : IStorageBroker
    {
        public List<string> GetAllData()
        {
            return new List<string>
            {
                "Cody",
                "Robert",
                "Hassan",
                "Kenny"
            };
        }
    }
}
