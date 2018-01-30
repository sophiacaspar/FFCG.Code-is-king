using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using FFCG.Weather.Models;

namespace FFCG.Weather.Importer
{
    class Program
    {
        static void Main(string[] args)
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
                    Longitude = station.longitude,
                    Latitude = station.latitude,
                    Altitude = station.height
                };

                weatherStations.Add(weatherStation);
            }

            StoreInLocalTextFile(weatherStations);

        }

        public static void StoreInLocalTextFile(List<WeatherStation> weatherStations)
        {
            var json = JsonConvert.SerializeObject(weatherStations);
            File.WriteAllText(@"C:\dev\repos\CodeIsKing\FFCG.Weather\src\weather.data\stations", json);
        }

    }
}
