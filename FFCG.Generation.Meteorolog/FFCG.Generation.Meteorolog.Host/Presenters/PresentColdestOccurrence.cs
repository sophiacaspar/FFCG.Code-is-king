using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFCG.Generation.Meteorolog.Host.Presenters
{
    public class PresentColdestOccurrence : IPresenter
    {
        public void Present(List<DailyValues> dailyValues)
        {
            var coldestData = GetColdestOccurrence(dailyValues);
            Console.WriteLine($"The coldest occurence was: {coldestData.Date} at " +
                                $"{coldestData.Time} with temperature: {coldestData.Temperature} degrees.");
        }

        public DailyValues GetColdestOccurrence(List<DailyValues> dailyValues)
        {
            float coldestTemperature = dailyValues.Min(t => t.Temperature);
            var coldestData = dailyValues.Where(dailyvalue => dailyvalue.Temperature == coldestTemperature).ToList();
            return coldestData[0];
        }
    }
}
