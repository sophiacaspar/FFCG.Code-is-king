using System;

namespace FFCG.Generation.Reverser.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var reverser = new Reverser();
            string output = reverser.Reverse("fOr");

            Console.WriteLine(output);
        }
    }
}
