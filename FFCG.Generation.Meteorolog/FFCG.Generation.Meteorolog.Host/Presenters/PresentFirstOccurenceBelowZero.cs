using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFCG.Generation.Meteorolog.Host.Presenters
{
    public class PresentFirstOccurenceBelowZero : IPresenter
    {
        public void Present(List<DailyValues> dailyValues)
        {
            var firstBelowZero = GetFirstOccurrenceOfBelowZero(dailyValues);
            Console.WriteLine($"First occurrence of a temperature below zero was: {firstBelowZero.Date} at " +
                                $"{firstBelowZero.Time} with temperature: {firstBelowZero.Temperature} degrees.");
        }

        public DailyValues GetFirstOccurrenceOfBelowZero(List<DailyValues> dailyValues)
        {
            DailyValues firstBelowZero = dailyValues.FirstOrDefault(t => t.Temperature < 0);
            return firstBelowZero;
        }
    }
}
