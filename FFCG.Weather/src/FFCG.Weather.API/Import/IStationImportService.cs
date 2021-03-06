﻿using System.Threading.Tasks;

namespace FFCG.Weather.API.Import
{
    public interface IStationImportService
    {
        Task<SmhiResponseObject> DownloadAllStations();
        Task<string> DownloadTemperatureReadingsForStation(string stationId);
    }
}
