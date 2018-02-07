
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FFCG.Weather.Models;
using System.Data.SqlClient;

namespace FFCG.Weather.API.Controllers
{
    [Route("api/[controller]")]
    public class StationsController : Controller
    {
        private SqlConnection SetupDatabaseConnection()
        {
            var connectionString =
                "Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CodeIsKingWeather;Integrated Security=SSPI;Trusted_Connection=yes;";
            return new SqlConnection(connectionString);
        }

        [HttpGet]
        public List<WeatherStation> Get()
        {
            var connection = SetupDatabaseConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Stations";
            var reader = command.ExecuteReader();

            var results = new List<WeatherStation>();
            while (reader.Read())
            {
                var weatherStation = MapToModel(reader);

                results.Add(weatherStation);
            }

            return results;
        }

        [HttpGet("{id}")]
        public WeatherStation Get(string id)
        {
            var connection = SetupDatabaseConnection();
            connection.Open();

            var command = connection.CreateCommand();

            // Absolutely not safe at all! This is here to show how nasty SQL Injection can be...
            command.CommandText = $"SELECT * FROM Stations WHERE id = '{id}'";

            var reader = command.ExecuteReader();

            if (!reader.HasRows)
                return new WeatherStation();

            reader.Read();
            var weatherStation = MapToModel(reader);

            return weatherStation;
        }

        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            // GET api/values
            [HttpGet]
            public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            // GET api/values/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }

            // POST api/values
            [HttpPost]
            public void Post([FromBody]string value)
            {
            }

            // PUT api/values/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE api/values/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }
        }

        private static WeatherStation MapToModel(SqlDataReader reader)
        {
            return new WeatherStation
            {
                Id = reader["id"].ToString(),
                Name = reader["name"].ToString(),
                Latitude = float.Parse(reader["latitude"].ToString()),
                Longitude = float.Parse(reader["longitude"].ToString()),
                Altitude = float.Parse(reader["altitude"].ToString()),
            };
        }
    }
}
