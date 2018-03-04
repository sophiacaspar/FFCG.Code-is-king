using FFCG.Weather.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FFCG.Weather.API.Import.Controllers
{
    [Route("api/import/smhi/stations")]
    public class ImportSmhiStationsController : ControllerBase
    {
        private readonly IWeatherStationBulkImportService _service;
        private readonly string _path;

        public ImportSmhiStationsController(IWeatherStationBulkImportService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Post()
        {
            _service.SaveAllWeatherStations();
            return Ok("Import completed!");
        }
    }
}