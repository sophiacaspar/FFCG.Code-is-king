using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace FFCG.Generation.Meteorolog
{
    public class FileReader
    {
        private UnixTimestampConverter _unixTimestampConverter = new UnixTimestampConverter();
        private string _pathToFile;
        private List<DailyValues> _dailyValues = new List<DailyValues>();

        public FileReader(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public void ReadFile()
        {
            try
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
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e);
            }

        }

        public void PresentData(IPresenter presenter)
        {
            presenter.Present(_dailyValues);
        }


    }
}
