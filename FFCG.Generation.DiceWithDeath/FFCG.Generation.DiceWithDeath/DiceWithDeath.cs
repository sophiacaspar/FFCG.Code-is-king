using System;

namespace FFCG.Generation.DiceWithDeath
{
    public class DiceWithDeath
    {

        private int score;
        private OutputStrings outputString = new OutputStrings();
        private Dice dice = new Dice();

        public void InitDiceWithDeath(int numberOfSidesOnDice)
        {
            SetInitialScore(0);

            Console.WriteLine(outputString.newGame);
            dice.NumberOfSidesOnDice = numberOfSidesOnDice;
            int currentDiceValue = dice.RollDice();

            Console.WriteLine(outputString.yourDiceRoll);
            Console.WriteLine(outputString.RollDice(currentDiceValue));
            PlayDiceWithDeath(currentDiceValue);
            
        }

        public void PlayDiceWithDeath(int currentDiceValue)
        {
            Console.WriteLine(outputString.Instructions(currentDiceValue));

            char inputChar = Console.ReadKey().KeyChar;
            int newDiceValue = dice.RollDice();

            if (inputChar == 'h' || inputChar == 'l')
            {
                Console.WriteLine(outputString.newDiceRoll);
                Console.WriteLine(outputString.RollDice(newDiceValue));

                if (CheckIfGuessIsCorrect(inputChar, currentDiceValue, newDiceValue))
                {
                    PlayDiceWithDeath(newDiceValue);
                }
                else
                {
                    GameOver();
                }
            }
            else if (inputChar == 'q')
            {
                return;
            }
            else
            {
                Console.WriteLine(outputString.wrongInput);
                PlayDiceWithDeath(currentDiceValue);
            }
        }

        public bool CheckIfGuessIsCorrect(char guess, int currentDiceValue, int newDiceValue)
        {
            if ((guess == 'h' && newDiceValue > currentDiceValue) || (guess == 'l' && newDiceValue < currentDiceValue))
            {
                Console.WriteLine(outputString.correctGuess);
                IncreaseScoreByOne();
                return true;
            }
            else if (currentDiceValue == newDiceValue)
            {
                Console.WriteLine(outputString.equalDiceValues);
                return true;
            }
            else
            {
                return false;
            }
        }


        public void GameOver()
        {
            int finalScore = GetScore();
            Console.WriteLine(outputString.death);
            Console.WriteLine(outputString.GameOver(finalScore));
            CheckIfNewGame();
        }

        public void CheckIfNewGame()
        {
            Console.WriteLine(outputString.playAgain);
            char inputChar = Console.ReadKey().KeyChar;
            if (inputChar == 'y')
            {
                InitDiceWithDeath(dice.NumberOfSidesOnDice);
            }
            else
            {
                return;
            }
        }

        public int GetScore() { return score; }
        public void SetInitialScore(int initialScore) { score = initialScore; }
        public void IncreaseScoreByOne() { score = score + 1; }
    }

    public class Score { 
}

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
                return random.Next(1, numberOfSidesOnDice +1);
            }            
        }
    }
}
