using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFCG.Generation.Meteorolog.Host.Presenters
{
    public class PresentWarmestOccurrence : IPresenter
    {
        public void Present(List<DailyValues> dailyValues)
        {
            var warmestData = GetWarmestOccurrence(dailyValues);
            Console.WriteLine($"The warmest occurence was: {warmestData.Date} at " +
                                $"{warmestData.Time} with temperature: {warmestData.Temperature} degrees.");
        }

        public DailyValues GetWarmestOccurrence(List<DailyValues> dailyValues)
        {
            float warmestTemperature = dailyValues.Max(t => t.Temperature);
            var warmestData = dailyValues.Where(dailyvalue => dailyvalue.Temperature == warmestTemperature).ToList();
            return warmestData[0];
        }
    }
}
