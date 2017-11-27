using System;

namespace FFCG.Generation.Meteorolog
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = @"C:\Users\sophia.caspar\source\repos\CodeIsKing\FFCG.Generation.Meteorolog\temperatures.csv";
            //string pathToFile = @"C:\Users\sophia.caspar\source\repos\CodeIsKing\FFCG.Generation.Meteorolog\temp.csv";
            FileReader fr = new FileReader(pathToFile);
            fr.ReadFile();
            fr.PresentDailyValues();
        }
    }
}
