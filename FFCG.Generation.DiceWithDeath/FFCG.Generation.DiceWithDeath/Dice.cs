using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Generation.DiceWithDeath
{
    public class Dice
    {
        private int numberOfSidesOnDice;
        public int NumberOfSidesOnDice
        {
            get { return numberOfSidesOnDice; }
            set
            {
                if (value < 3) { numberOfSidesOnDice = 3; }
                else { numberOfSidesOnDice = value; }
            }
        }

        public int RollDice(int optionalSeed = 0)
        {
            if (optionalSeed == 0)
            {
                Random random = new Random();
                return random.Next(1, numberOfSidesOnDice + 1);
            }
            else
            {
                Random random = new Random(optionalSeed);
                return random.Next(1, numberOfSidesOnDice + 1);
            }
        }
    }
}
