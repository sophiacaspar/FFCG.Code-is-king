using FFCG.Weather.API.Data;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FFCG.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportSmhiStationsController : ControllerBase
    {
        private readonly IStationImportService _stationImportService;
        private readonly WeatherContext _db;

        public ImportSmhiStationsController(WeatherContext db, IStationImportService stationImportService)
        {
            _db = db;
            _stationImportService = stationImportService;
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var root = await _stationImportService.DownloadAllStations();

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