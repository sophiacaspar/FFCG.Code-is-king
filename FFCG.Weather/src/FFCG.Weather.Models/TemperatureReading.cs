using System;

namespace FFCG.Weather.Models
{
    public class TemperatureReading
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public string StationId { get; set; }
    }
}
