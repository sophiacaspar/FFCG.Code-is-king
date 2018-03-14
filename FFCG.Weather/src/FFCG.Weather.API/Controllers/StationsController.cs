
using System.Collections.Generic;
using System.Linq;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FFCG.Weather.API.Controllers
{

    [Route("api/[controller]")]
    public class StationsController : Controller
    {

        private readonly IWeatherStationRepository _repository;

        public StationsController(IWeatherStationRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public List<WeatherStation> Get()
        {
            return _repository.All().OrderBy(x => x.Name).ToList();
        }

        [HttpGet("{id}")]
        public WeatherStation Get(string id)
        {
            return _repository.Load(id);
        }

        [HttpGet("{id}/temperatures")]
        public IEnumerable<TemperatureReadingViewModel> GetReadings(string id)
        {
            var readings = _repository.GetReadingsByStationId(id);

            return readings.Select(r => new TemperatureReadingViewModel
            {
                Date = r.Date,
                Temperature = r.Temperature
            });
        }
    }
    public class TemperatureReadingViewModel
    {
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
    }
}