using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace FFCG.Generation.Meteorolog
{
    public class Meteorolog
    {
        public void GetFirstOccurrenceOfBelowZero()
        {

        }

        public void GetTheColdestOccurrence()
        {

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

        public FileReader(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        private class DailyValues
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public float Temperature { get; set; }
        }

        public void ReadFile()
        {
            var csvLines = File.ReadAllLines(_pathToFile).Skip(1);
            foreach (var csvLine in csvLines)
            {
                string[] values = csvLine.Split(';');
                var unixTimestamp = Convert.ToInt32(values[0].Trim('"'));

                DailyValues dailyValues = new DailyValues
                {
                    Date = _unixTimestampConverter.GetDateFromTimestamp(unixTimestamp),
                    Time = _unixTimestampConverter.GetTimeFromTimestamp(unixTimestamp),
                    Temperature = float.Parse(values[1].Trim('"'), CultureInfo.InvariantCulture.NumberFormat)
                };
                _dailyValues.Add(dailyValues);
            }
                                           
        }
    }
}
