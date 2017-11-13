using System;

namespace FFCG.Generation.DiceWithDeath.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var dwd = new DiceWithDeath();
            int numberOfSidesOnDice = 18;
            dwd.InitDiceWithDeath(numberOfSidesOnDice);

        }
    }
}
