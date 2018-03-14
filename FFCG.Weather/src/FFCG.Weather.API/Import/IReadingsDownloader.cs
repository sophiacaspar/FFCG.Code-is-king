using FFCG.Weather.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFCG.Weather.API.Import
{
    public interface IReadingsDownloader
    {
        Task<string> Download(string stationId);
    }
}
