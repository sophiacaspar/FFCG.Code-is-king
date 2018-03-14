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
        private readonly IReadingsDownloader _readingsDownloader;

        public ImportSmhiReadingsController(WeatherContext context, IReadingsDownloader readingsDownloader)
        {
            _context = context;
            _readingsDownloader = readingsDownloader;
        }

        [HttpPost]
        [Route("{id}/readings")]
        public async Task<IActionResult> Post(string id)
        {
            var station = await _context.Stations.FindAsync(id);

            if (station == null)
                return BadRequest($"No station found with id: {id}");

            string url = $"https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1/station/{id}/period/corrected-archive/data.csv";

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);

            //_readingsDownloader.Download(id);
            var readings = new List<TemperatureReading>();
            var temperatureReadings = response.Split('\n').Skip(10).Where(line => line.Length > 0);

            foreach (var temperatureReading in temperatureReadings)
            {
                readings.Add(TemperatureReadingHandler(temperatureReading, id));
            }

            //var readings = response.Split('\n').Skip(10).Where(line => line.Length > 0).Select(line =>
            //{
            //    var row = line.Split(';');

            //    var date = row[0];
            //    var time = row[1];
            //    var temperature = row[2];

            //    var couldParse = DateTime.TryParse(date + " " + time, out var dateTime);
            //    if (!couldParse)
            //        return null;

            //    var temperatureValue = double.Parse(temperature.Replace('.', ','));

            //    return new TemperatureReading
            //    {
            //        StationId = id,
            //        Date = dateTime,
            //        Temperature = temperatureValue
            //    };
            //}).ToList();

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
                Temperature = double.Parse(row[2]),
                StationId = stationId
            };

            return temperatureReading;

        }
    }
}
