using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FFCG.Weather.API.Data;
using FFCG.Weather.API.Import;
using Xunit;
using FFCG.Weather.API.Controllers;
using FFCG.Weather.API.Import.Controllers;
using FFCG.Weather.API.Repositories;
using FFCG.Weather.Models;

namespace FFCG.Weather.Tests
{
    public class ImportSmhiStationsControllerTests
    {
        [Fact]
        public async Task Should_store_returned_stations_in_database()
        {
            var options = new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new WeatherContext(options))
            {
                var controller = new ImportSmhiStationsController(context, new DummyStationsDownloader());
                await controller.Post();
            }

            using (var context = new WeatherContext(options))
            {
                var first = await context.Stations.FirstAsync(x => x.Id == "1");
                var second = await context.Stations.FirstAsync(x => x.Id == "2");

                Assert.Equal("Teststation 1", first.Name);
                Assert.Equal(10, first.Altitude);
                Assert.Equal(20, first.Latitude);
                Assert.Equal(30, first.Longitude);

                Assert.Equal("Teststation 2", second.Name);
                Assert.Equal(15, second.Altitude);
                Assert.Equal(25, second.Latitude);
                Assert.Equal(35, second.Longitude);
            }
        }

        [Fact]
        public void Should_return_station_from_database_based_on_id()
        {
            var options = new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var weatherContext = new WeatherContext(options))
            {
                weatherContext.Stations.AddRange(new List<WeatherStation>
                {
                    new WeatherStation{Id = "1", Name = "Teststation 1", Altitude = 10, Latitude = 20, Longitude = 30},
                    new WeatherStation{ Id = "2", Name = "Teststation 2", Altitude = 15, Latitude = 25, Longitude = 35}
                });
                weatherContext.SaveChanges();
            }

            using (var weatherContext = new WeatherContext(options))
            {
                var stationsController = new StationsController(new WeatherStationRepository(weatherContext));
                var weatherStation = stationsController.Get("1");
                Assert.Equal("Teststation 1", weatherStation.Name);
                Assert.Equal(10, weatherStation.Altitude);
                Assert.Equal(20, weatherStation.Latitude);
                Assert.Equal(30, weatherStation.Longitude);
            }

        }

        [Fact]
        public void Should_return_number_of_stations_stored_in_database()
        {
            var options = new DbContextOptionsBuilder<WeatherContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var weatherContext = new WeatherContext(options))
            {
                weatherContext.Stations.AddRange(new List<WeatherStation>
                {
                    new WeatherStation{Id = "1", Name = "Teststation 1", Altitude = 10, Latitude = 20, Longitude = 30},
                    new WeatherStation{ Id = "2", Name = "Teststation 2", Altitude = 15, Latitude = 25, Longitude = 35}
                });
                weatherContext.SaveChanges();
            }

            using (var weatherContext = new WeatherContext(options))
            {
                var stationsController = new StationsController(new WeatherStationRepository(weatherContext));
                var weatherStations = stationsController.Get();
                Assert.Equal(2, weatherStations.Count);
            }

        }
    }

    public class DummyStationsDownloader : IStationImportService
    {
        public Task<SmhiResponseObject> DownloadAllStations()
        {
            var response = new SmhiResponseObject();
            response.station = new[]
            {
                new Station{ id = 1, name = "Teststation 1", height = 10, latitude = 20, longitude = 30},
                new Station{ id = 2, name = "Teststation 2", height = 15, latitude = 25, longitude = 35}
            };

            return Task.Run(() => response);
        }
    }
}
