using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataProcessorService dataProcessorService;

        public DataController(IDataProcessorService dataProcessorService)
        {
            this.dataProcessorService = dataProcessorService;
        }

        // GET: api/Data
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return this.dataProcessorService.ProcessData();
        }

        // GET: api/Data/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Data
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Data/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
