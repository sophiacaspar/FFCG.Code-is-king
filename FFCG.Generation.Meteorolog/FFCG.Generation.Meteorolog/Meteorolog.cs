using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

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

    public class FileReader
    {
        private UnixTimestampConverter _unixTimestampConverter = new UnixTimestampConverter();
        private string _pathToFile;
        private List<DailyValues> _dailyValues = new List<DailyValues>();
        private Meteorolog _meteorolog = new Meteorolog();

        public FileReader(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public void ReadFile()
        {
            var csvLines = File.ReadAllLines(_pathToFile).Skip(1);
            foreach (var csvLine in csvLines)
            {
                string[] values = csvLine.Split(';');
                var unixTimestamp = Convert.ToInt32(values[0].Trim('"'));

                DailyValues dailyvalues = new DailyValues
                {
                    Date = _unixTimestampConverter.GetDateFromTimestamp(unixTimestamp),
                    Time = _unixTimestampConverter.GetTimeFromTimestamp(unixTimestamp),
                    Temperature = float.Parse(values[1].Trim('"'), CultureInfo.InvariantCulture.NumberFormat)
                };
                _dailyValues.Add(dailyvalues);
            }
                                           
        }

        public void PresentDailyValues()
        {
            _meteorolog.PresentDailyValues(_dailyValues);
        }
    }

    public class DailyValues
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public float Temperature { get; set; }
    }
}
