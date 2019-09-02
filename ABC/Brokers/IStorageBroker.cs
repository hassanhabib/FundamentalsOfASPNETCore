using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Brokers
{
    public interface IStorageBroker
    {
        List<string> GetAllData();
    }
}
