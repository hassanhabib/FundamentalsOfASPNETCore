using ABC.Brokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC.Services
{
    public class DataProcessorService : IDataProcessorService
    {
        private readonly IStorageBroker storageBroker;

        public DataProcessorService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public List<string> ProcessData()
        {
            return this.storageBroker.GetAllData()
                .Select(item => item.ToUpper())
                .ToList();
        }
    }
}
