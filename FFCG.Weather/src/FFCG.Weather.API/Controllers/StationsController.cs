
using System.Collections.Generic;
using System.Linq;
using FFCG.Weather.Data;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;

namespace FFCG.Weather.API.Controllers
{

    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        [HttpGet]
        public List<WeatherStation> Get()
        {
            using (var db = new WeatherContext())
            {
                return db.Stations.ToList();
            }
        }

        [HttpGet("{id}")]
        public WeatherStation Get(string id)
        {
            using (var db = new WeatherContext())
            {
                return db.Stations.FirstOrDefault(x => x.Id == id);
            }
        }
    }
}