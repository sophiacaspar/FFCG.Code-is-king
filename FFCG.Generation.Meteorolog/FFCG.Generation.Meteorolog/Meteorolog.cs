using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace FFCG.Generation.Meteorolog
{
    public class Meteorolog
    {
    }

    public class FileReader
    {
        private string _pathToFile;
        private List<DailyValues> _dailyValues = new List<DailyValues>();

        private class DailyValues
        {
            public long epochTimestamp { get; set; }
            public float temperature { get; set; }

            public static DailyValues FromCsv(string csvLine)
            {
                string[] values = csvLine.Split(';');
                DailyValues dailyValues = new DailyValues();
                dailyValues.epochTimestamp = Convert.ToInt32(values[0].Trim('"'));
                dailyValues.temperature = float.Parse(values[1].Trim('"'), CultureInfo.InvariantCulture.NumberFormat);
                Console.WriteLine(dailyValues.epochTimestamp + " " + dailyValues.temperature );
                return dailyValues;
            }
        }

        public FileReader(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public void ReadFile()
        {
            List<DailyValues> values = File.ReadAllLines(_pathToFile)
                                           .Skip(1)
                                           .Select(v => DailyValues.FromCsv(v))
                                           .ToList();
        }
    }
}
