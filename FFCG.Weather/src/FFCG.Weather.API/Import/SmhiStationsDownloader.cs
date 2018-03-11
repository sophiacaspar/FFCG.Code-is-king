using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FFCG.Weather.API.Import
{
    public class SmhiStationsDownloader : IStationsDownloader
    {
        private readonly ExternalEndpoints _endpoints;

        public SmhiStationsDownloader(ExternalEndpoints endpoints)
        {
            _endpoints = endpoints;
        }

        public async Task<SmhiResponseObject> Download()
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync(_endpoints.BaseUrl);

            var root = JsonConvert.DeserializeObject<SmhiResponseObject>(response);
            return root;
        }
    }
}
