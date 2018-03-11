using System;
using System.Collections.Generic;
using FFCG.Weather.Models;
using FFCG.Weather.API.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace FFCG.Weather.API.Import
{
    public class WeatherStationBulkImportService : IWeatherStationBulkImportService
    {
        private readonly WeatherContext _db;
        private readonly IAppSettings _appSettings;

        public WeatherStationBulkImportService(WeatherContext db, IConfiguration configuration)
        {
            _db = db;
            _appSettings = appSettings;
        }
        public void SaveAllWeatherStations()
        {
            var httpClient = new HttpClient();
            var apiPath = _appSettings.Get("ApiImportConnections", "SmhiStations");
            var response = httpClient.GetStringAsync(apiPath).Result;
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
        }
    }
}
