using Microsoft.EntityFrameworkCore;
using FFCG.Weather.Models;

namespace FFCG.Weather.Data
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // TODO: Change location of connection string
        //    optionsBuilder.UseSqlServer(
        //        "Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=CodeIsKingWeather.EF;Integrated Security=SSPI;Trusted_Connection=yes;");
        //}

        public DbSet<WeatherStation> Stations { get; set; }
    }
}
