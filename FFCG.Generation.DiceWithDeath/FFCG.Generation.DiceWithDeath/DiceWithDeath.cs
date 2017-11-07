using System;

namespace FFCG.Generation.DiceWithDeath
{
    public class DiceWithDeath
    {

        private int score;

        public int GetScore() { return score; }
        public void SetInitialScore(int initialScore) { score = initialScore; }
        public void IncreaseScoreByOne() { score = score + 1; }

        public void InitDiceWithDeath()
        {
            SetInitialScore(0);
            var dice = new Dice();
            var outputString = new OutputStrings();

            Console.WriteLine(outputString.newGame);
            int currentDiceValue = dice.RollDice();

            Console.WriteLine(outputString.yourDiceRoll);
            Console.WriteLine(outputString.RollDice(currentDiceValue));
            PlayDiceWithDeath(currentDiceValue);
            
        }

        public void PlayDiceWithDeath(int currentDiceValue)
        {
            var outputString = new OutputStrings();
            var dice = new Dice();

            Console.WriteLine(outputString.Instructions(currentDiceValue));

            char inputChar = Console.ReadKey().KeyChar;
            int newDiceValue = dice.RollDice();

            if (inputChar == 'h' || inputChar == 'l')
            {
                Console.WriteLine(outputString.newDiceRoll);
                Console.WriteLine(outputString.RollDice(newDiceValue));
                if (CheckIfGuessIsCorrect(inputChar, currentDiceValue, newDiceValue))
                {
                    Console.WriteLine(outputString.correctGuess);
                    IncreaseScoreByOne();
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
            if (guess == 'h')
            {
                return (newDiceValue >= currentDiceValue);
            }
            else if (guess == 'l')
            {
                return (newDiceValue < currentDiceValue);
            }
            else
            {
                return false;
            }
        }

        public void GameOver()
        {
            var outputString = new OutputStrings();
            int finalScore = GetScore();
            Console.WriteLine(outputString.death);
            Console.WriteLine(outputString.GameOver(finalScore));
            Console.ReadKey();
        }
    }

    public class Dice
    {
        public int RollDice(int optionalSeed = 0)
        {
            if (optionalSeed == 0)
            {
                Random random = new Random();
                return random.Next(1, 7);
            }
            else
            {
                Random random = new Random(optionalSeed);
                return random.Next(1, 7);
            }            
        }
    }
}
