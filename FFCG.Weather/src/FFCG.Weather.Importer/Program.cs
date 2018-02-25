using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using FFCG.Weather.Data;
using FFCG.Weather.Models;
using Newtonsoft.Json;

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

            //StoreInLocalTextFile(weatherStations);
            //StoreInLocalDatabase(weatherStations);
            StoreWithEntityFramework(weatherStations);

            Console.WriteLine();
            Console.WriteLine("All done!");

        }

        private static void StoreWithEntityFramework(List<WeatherStation> weatherStations)
        {
            using (var db = new WeatherContext())
            {
                db.Stations.AddRange(weatherStations);
                db.SaveChanges();
            }
        }

        public static void StoreInLocalDatabase(List<WeatherStation> weatherStations)
        {
            var connectionString =
                "Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CodeIsKingWeather;Integrated Security=SSPI;Trusted_Connection=yes;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            int i = 0;

            foreach (var station in weatherStations)
            {
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO Stations VALUES ('{station.Id}', '{station.Name}', {station.Longitude.ToString().Replace(",", ".")}, {station.Latitude.ToString().Replace(",", ".")}, {station.Altitude.ToString().Replace(",", ".")});";

                command.ExecuteNonQuery();
                i++;
                var progress = (decimal)i / weatherStations.Count;

                Console.Write($"\r{progress:P}");
            }
        }

        public static void StoreInLocalTextFile(List<WeatherStation> weatherStations)
        {
            var json = JsonConvert.SerializeObject(weatherStations);
            File.WriteAllText(@"C:\dev\repos\CodeIsKing\FFCG.Weather\src\weather.data\stations", json);
        }

    }
}
