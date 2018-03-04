﻿
using FFCG.Weather.API.Data;
using FFCG.Weather.API.Repositories;
using FFCG.Weather.API.Import;
using FFCG.Weather.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FFCG.Weather.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WeatherContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IAppSettings>(new AppSettings(Configuration));
            services.AddScoped<IWeatherStationRepository, WeatherStationRepository>();
            services.AddScoped<IWeatherStationBulkImportService, WeatherStationBulkImportService>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }

    public interface IAppSettings
    {
        string Get(string section, string variableName);
    }

    public class AppSettings : IAppSettings
    {
        private IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Get(string section, string variableName)
        {
            var result = _configuration.GetSection($"{section}:{variableName}");
            return result.Value;
        }
    }
}