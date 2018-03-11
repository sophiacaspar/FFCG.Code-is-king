using System.Threading.Tasks;

namespace FFCG.Weather.API.Import
{
    public interface IStationsDownloader
    {
        Task<SmhiResponseObject> Download();
    }
}
