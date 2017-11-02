using System;

namespace FFCG.Generation.FizzBuzz.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            int minValue = 1;
            int maxValue = 100;
            var fizzbuzz = new FizzBuzz();
            fizzbuzz.RunFizzBuzz(minValue, maxValue);

        }
    }
}
