using System.Collections.Generic;

namespace FFCG.Weather.Models
{
    public interface IWeatherStationRepository
    {
        WeatherStation Load(string id);
        WeatherStation Save(WeatherStation station);
        IEnumerable<WeatherStation> All();
    }
}
