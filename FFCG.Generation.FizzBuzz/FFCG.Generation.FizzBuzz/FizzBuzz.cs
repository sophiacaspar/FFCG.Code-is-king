using System;

namespace FFCG.Generation.FizzBuzz
{
    public class FizzBuzz
    {

        public void RunFizzBuzz(int minValue, int maxValue)
        {
            for (int i = minValue; i <= maxValue; i++)
            {
                if (IsFizzBuzz(i))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (IsFizz(i))
                {
                    Console.WriteLine("Fizz");
                }
                else if (IsBuzz(i))
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        public bool IsFizzBuzz(int num)
        {
            return ((num % 3 == 0) && (num % 5 == 0));
        }

        public bool IsFizz(int num)
        {
            return ((num % 3 == 0) && (num % 5 != 0));
        }

        public bool IsBuzz(int num)
        {
            return ((num % 3 != 0) && (num % 5 == 0));
        }
    }
}
