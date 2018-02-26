using Microsoft.EntityFrameworkCore;
using FFCG.Weather.Models;

namespace FFCG.Weather.API.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {}

        public DbSet<WeatherStation> Stations { get; set; }
    }
}
