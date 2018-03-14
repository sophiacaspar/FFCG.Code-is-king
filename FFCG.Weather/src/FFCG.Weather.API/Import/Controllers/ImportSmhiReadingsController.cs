using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FFCG.Weather.API.Data;
using System.Net.Http;
using FFCG.Weather.Models;

namespace FFCG.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportSmhiReadingsController : ControllerBase
    {
        private readonly WeatherContext _context;
        private readonly IStationImportService _stationImportService;

        public ImportSmhiReadingsController(WeatherContext context, IStationImportService stationImportService)
        {
            _context = context;
            _stationImportService = stationImportService;
        }

        [HttpPost]
        [Route("{id}/readings")]
        public async Task<IActionResult> Post(string id)
        {
            var station = await _context.Stations.FindAsync(id);

            if (station == null)
                return BadRequest($"No station found with id: {id}");

           
            var response = await _stationImportService.DownloadTemperatureReadingsForStation(id);
            var readings = new List<TemperatureReading>();
            var temperatureReadings = response.Split('\n').Skip(10).Where(line => line.Length > 0).Select(line => line);

            foreach (var temperatureReading in temperatureReadings)
            {
                readings.Add(TemperatureReadingHandler(temperatureReading, id));
            }

            await _context.TemperatureReadings.AddRangeAsync(readings.Where(x => x != null));
            await _context.SaveChangesAsync();

            return Ok();
        }

        private TemperatureReading TemperatureReadingHandler(string reading, string stationId)
        {
            var row = reading.Split(";");
            var splitDate = Array.ConvertAll(row[0].Split("-"), int.Parse);
            var splitTime = Array.ConvertAll(row[1].Split(":"), int.Parse);
            var temperatureReading = new TemperatureReading
            {
                Date = new DateTime(splitDate[0], splitDate[1], splitDate[2], splitTime[0], splitTime[1], splitTime[2]),
                Temperature = double.Parse(row[2].Replace('.', ',')),
                StationId = stationId
            };

            return temperatureReading;

        }
    }
}
