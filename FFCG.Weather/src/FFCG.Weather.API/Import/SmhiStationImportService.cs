using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FFCG.Weather.API.Import
{
    public class SmhiStationImportService : IStationImportService
    {
        private readonly ExternalEndpoints _endpoints;

        public SmhiStationImportService(ExternalEndpoints endpoints)
        {
            _endpoints = endpoints;
        }

        public async Task<SmhiResponseObject> DownloadAllStations()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(_endpoints.BaseUrl);

            var root = JsonConvert.DeserializeObject<SmhiResponseObject>(response);
            return root;
        }
    }
}
