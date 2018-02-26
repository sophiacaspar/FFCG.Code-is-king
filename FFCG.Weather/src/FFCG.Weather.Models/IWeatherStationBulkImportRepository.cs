using System.Collections.Generic;

namespace FFCG.Weather.Models
{
    public interface IWeatherStationBulkImportRepository
    {
        void ImportAll(string path);
    }
}
