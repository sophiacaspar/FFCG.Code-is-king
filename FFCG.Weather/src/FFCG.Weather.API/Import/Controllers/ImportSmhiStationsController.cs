using System.Collections.Generic;
using System.Net.Http;
using FFCG.Weather.API.Data;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FFCG.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportSmhiStationsController : ControllerBase
    {
        private readonly WeatherContext _db;
        public ImportSmhiStationsController(WeatherContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult Post()
        {
            var httpClient = new HttpClient();

            var response = httpClient.GetStringAsync("https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1.json").Result;

            var root = JsonConvert.DeserializeObject<SmhiResponseObject>(response);

            var weatherStations = new List<WeatherStation>();

            foreach (var station in root.station)
            {
                var weatherStation = new WeatherStation
                {
                    Id = station.id.ToString(),
                    Name = station.name,
                    Altitude = station.height,
                    Latitude = station.latitude,
                    Longitude = station.longitude
                };

                weatherStations.Add(weatherStation);
            }

            _db.AddRange(weatherStations);
            _db.SaveChanges();

            return Ok("Import completed!");
        }
    }
}