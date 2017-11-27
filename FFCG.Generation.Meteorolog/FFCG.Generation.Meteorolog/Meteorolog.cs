using System;
using System.Linq;
using System.Collections.Generic;

namespace FFCG.Generation.Meteorolog
{
    public class Meteorolog
    {
        private float _temperature;

        public void PresentDailyValues(List<DailyValues> dailyValues)
        {
            DailyValues firstBelowZero = GetFirstOccurrenceOfBelowZero(dailyValues);
            Console.WriteLine($"{firstBelowZero.Date} {firstBelowZero.Time} {firstBelowZero.Temperature}");
        }

        public DailyValues GetFirstOccurrenceOfBelowZero(List<DailyValues> dailyValues)
        {
            DailyValues firstBelowZero = dailyValues.FirstOrDefault(t => t.Temperature<0);
            return firstBelowZero;
        }

        public void GetTheColdestOccurrence(List<DailyValues> dailyValues)
        {
            //float coldestData = dailyValues.Min(t => t.Temperature);
        }

        public void GetTheWarmestOccurrence()
        {

        }

        public void GetAverageTemperaturePerDay()
        {

        }
    }



    public class DailyValues
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public float Temperature { get; set; }
    }
}
