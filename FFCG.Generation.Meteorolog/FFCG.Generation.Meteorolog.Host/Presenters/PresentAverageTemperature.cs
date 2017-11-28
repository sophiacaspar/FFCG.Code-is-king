using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFCG.Generation.Meteorolog.Host.Presenters
{
    public class PresentAverageTemperature : IPresenter
    {
        public void Present(List<DailyValues> dailyValues)
        {
            var averagePerDay = GetAverageTemperaturePerDay(dailyValues);
            foreach (var day in averagePerDay)
            {
                Console.WriteLine($"Average temperature {day.Date} was: {day.Temperature.ToString("F2")} degrees.");
            }
            
        }

        public List<DailyValues> GetAverageTemperaturePerDay(List<DailyValues> dailyValues)
        {
            var average = dailyValues.GroupBy(dailyValue => dailyValue.Date, dailyValue => dailyValue.Temperature,
                            (date, temp) => new DailyValues { Date = date, Temperature = temp.Average() }).ToList();
            return average;
        }
    }
}
