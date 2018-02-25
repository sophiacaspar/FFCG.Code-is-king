using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Weather.Models
{
    public interface IWeatherStationRepository
    {
        WeatherStation Load(string id);
        WeatherStation Save(WeatherStation station);
        IEnumerable<WeatherStation> All();
    }
}
