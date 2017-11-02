using System;

namespace FFCG.Generation.Calculator.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter value one: ");
            string value1 = Console.ReadLine();

            Console.Write("Enter value two: ");
            string value2 = Console.ReadLine();

            int intValue1 = int.Parse(value1);
            int intValue2 = int.Parse(value2);

            
            var calculator = new Calculator();
            var result = calculator.Add(intValue1, intValue2);

            Console.WriteLine($"We have values: {value1} and value {value2}");
            Console.WriteLine($"Result: {result}");
        }
    }
}
