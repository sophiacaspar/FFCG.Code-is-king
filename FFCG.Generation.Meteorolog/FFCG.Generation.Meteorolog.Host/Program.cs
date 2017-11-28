using FFCG.Generation.Meteorolog.Host.Presenters;
using System;
using System.Collections.Generic;

namespace FFCG.Generation.Meteorolog
{
    class Program
    {
        static void Main(string[] args)
        {
            var presentFirstOccurrenceBelowZero = new PresentFirstOccurenceBelowZero();
            var presentColdestOccurrence = new PresentColdestOccurrence();
            var presentWarmestOccurrence = new PresentWarmestOccurrence();
            var presentAverageTemperature = new PresentAverageTemperature();
            var presentAll = new PresentAll(new List<IPresenter> {
                                                                    presentFirstOccurrenceBelowZero,
                                                                    presentColdestOccurrence,
                                                                    presentWarmestOccurrence,
                                                                    presentAverageTemperature
                                                                });

            string pathToFile = @"C:\Users\sophia.caspar\source\repos\CodeIsKing\FFCG.Generation.Meteorolog\temperatures.csv";
            var fileReader = new FileReader(pathToFile);
            fileReader.ReadFile();
            fileReader.PresentData(presentAll);
        }
    }
}
