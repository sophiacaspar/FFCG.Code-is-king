using System;

namespace FFCG.Generation.DiceWithDeath.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwd = new DiceWithDeath();
            int numberOfSidesOnDice = 6;
            dwd.InitDiceWithDeath(numberOfSidesOnDice);

        }
    }
}
