using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FFCG.Weather.Models;
using Newtonsoft.Json;

namespace FFCG.Weather.API.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        [HttpGet]
        public List<WeatherStation> Get()
        {
            string path = @"C:\dev\repos\CodeIsKing\FFCG.Weather\src\weather.data\stations";
            var json = System.IO.File.ReadAllText(path);
            var stations = JsonConvert.DeserializeObject<List<WeatherStation>>(json);
            return stations;
        }
    }


    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
