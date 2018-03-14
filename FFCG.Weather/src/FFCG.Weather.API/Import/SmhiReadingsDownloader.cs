using FFCG.Weather.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FFCG.Weather.API.Import
{
    public class SmhiReadingsDownloader : IReadingsDownloader
    {
        private readonly ExternalEndpoints _endpoints;

        public SmhiReadingsDownloader(ExternalEndpoints endpoints)
        {
            _endpoints = endpoints;
        }

        public async Task<string> Download(string stationId)
        {
            var httpClient = new HttpClient();

            var smhiReadingsUrl = _endpoints.ReadingsBaseUrl.Replace("{id}", stationId);

            var response = await httpClient.GetStringAsync(smhiReadingsUrl);

            return response;
        }
    }
}
