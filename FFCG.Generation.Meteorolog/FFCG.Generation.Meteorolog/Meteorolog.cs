using System;
using System.Linq;
using System.Collections.Generic;

namespace FFCG.Generation.Meteorolog
{
    public class Meteorolog
    {

        public void PresentDailyValues(List<DailyValues> dailyValues)
        {
            DailyValues firstBelowZero = GetFirstOccurrenceOfBelowZero(dailyValues);
            Console.WriteLine($"{firstBelowZero.Date} {firstBelowZero.Time} {firstBelowZero.Temperature}");
            DailyValues coldestOccurrence = GetColdestOccurrence(dailyValues);
            DailyValues warmestOccurrence = GetWarmestOccurrence(dailyValues);
            Console.WriteLine($"{warmestOccurrence.Date} {warmestOccurrence.Time} {warmestOccurrence.Temperature}");
        }

        public DailyValues GetFirstOccurrenceOfBelowZero(List<DailyValues> dailyValues)
        {
            DailyValues firstBelowZero = dailyValues.FirstOrDefault(t => t.Temperature<0);
            return firstBelowZero;
        }

        public DailyValues GetColdestOccurrence(List<DailyValues> dailyValues)
        {
            float coldestTemperature = dailyValues.Min(t => t.Temperature);
            var coldestData = dailyValues.Where(dailyvalue=> dailyvalue.Temperature == coldestTemperature).ToList();
            return coldestData[0];
        }

        public DailyValues GetWarmestOccurrence(List<DailyValues> dailyValues)
        {
            float warmestTemperature = dailyValues.Max(t => t.Temperature);
            var coldestData = dailyValues.Where(dailyvalue => dailyvalue.Temperature == warmestTemperature).ToList();
            return coldestData[0];
        }

        public List<DailyValues> GetAverageTemperaturePerDay(List<DailyValues> dailyValues)
        {
            var average = dailyValues.GroupBy(dailyValue => dailyValue.Date, dailyValue => dailyValue.Temperature,
                            (date, temp) => new DailyValues { Date = date, Temperature = temp.Average() }).ToList();
            return average;
        }
    }



    public class DailyValues
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public float Temperature { get; set; }
    }
}
