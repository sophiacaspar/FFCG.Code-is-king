using System;
using System.Collections.Generic;
using FFCG.Weather.Models;
using FFCG.Weather.API.Data;
using FFCG.Weather.API.Import;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;

namespace FFCG.Weather.API.Repositories
{
    public class WeatherStationBulkImportRepository : IWeatherStationBulkImportRepository
    {
        private readonly WeatherContext _db;

        public WeatherStationBulkImportRepository(WeatherContext db)
        {
            _db = db;
        }
        public void ImportAll(string path)
        {
            _db.AddRange(GetAllWeatherStations(path));
            _db.SaveChanges();
        }

        private List<WeatherStation> GetAllWeatherStations(string path)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetStringAsync(path).Result;
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
            return weatherStations;
        }
    }
}
