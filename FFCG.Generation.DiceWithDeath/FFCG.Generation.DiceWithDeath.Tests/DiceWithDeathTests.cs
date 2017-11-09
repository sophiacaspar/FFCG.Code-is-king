using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Bygg ett spel som går ut på att gissa om nästkommande tärningskast är högre eller lägre än det senaste.
 * Gissar man rätt får man en poäng och får sedan försöka igen, men gissar man fel vinner Döden och spelet tar slut och din poäng visas.
 * 
 */


namespace FFCG.Generation.DiceWithDeath.Tests
{
    [TestClass]
    public class DiceWithDeathTests
    {
        private DiceWithDeath _diceWithDeath;
        private Dice _dice;


        [TestInitialize]
        public void SetUp()
        {
            _diceWithDeath = new DiceWithDeath();
            _dice = new Dice();

        }

        [TestMethod]
        public void Rolled_dice_result_should_be_six()
        {
            int rolledDiceResult = _dice.RollDice(123);
            Assert.AreEqual(6, rolledDiceResult);
        }

        [TestMethod]
        public void Should_guess_higher_and_be_right()
        {
            int currentDiceValue = _dice.RollDice(321);
            int newDiceValue = _dice.RollDice(123);
            char newGuess = 'h';
            bool checkIfGuessIsRight = _diceWithDeath.CheckIfGuessIsCorrect(newGuess, currentDiceValue, newDiceValue);
            Assert.IsTrue(checkIfGuessIsRight);
        }

        [TestMethod]
        public void Should_guess_lower_and_be_wrong()
        {
            int currentDiceValue = _dice.RollDice(321);
            int newDiceValue = _dice.RollDice(123);
            char newGuess = 'l';
            bool checkIfGuessIsRight = _diceWithDeath.CheckIfGuessIsCorrect(newGuess, currentDiceValue, newDiceValue);
            Assert.IsFalse(checkIfGuessIsRight);
        }

        [TestMethod]
        public void Should_guess_higher_and_be_right_with_same_values_on_dices()
        {
            int currentDiceValue = _dice.RollDice(321);
            int newDiceValue = _dice.RollDice(321);
            char newGuess = 'h';
            bool checkIfGuessIsRight = _diceWithDeath.CheckIfGuessIsCorrect(newGuess, currentDiceValue, newDiceValue);
            Assert.IsTrue(checkIfGuessIsRight);
        }

        [TestMethod]
        public void Right_guess_should_increase_score_by_one()
        {
            int oldScore = 4;
            _diceWithDeath.SetInitialScore(oldScore);
            int currentDiceValue = _dice.RollDice(321);
            int newDiceValue = _dice.RollDice(123);
            char newGuess = 'h';
            bool checkIfGuessIsRight = _diceWithDeath.CheckIfGuessIsCorrect(newGuess, currentDiceValue, newDiceValue);
            int newScore = _diceWithDeath.GetScore();
            Assert.AreEqual(oldScore + 1, newScore);
        }

        [TestMethod]
        public void Guess_where_both_dice_values_are_equal_should_keep_same_score()
        {
            int oldScore = 4;
            _diceWithDeath.SetInitialScore(oldScore);
            int currentDiceValue = _dice.RollDice(123);
            int newDiceValue = _dice.RollDice(123);
            char newGuess = 'h';
            bool checkIfGuessIsRight = _diceWithDeath.CheckIfGuessIsCorrect(newGuess, currentDiceValue, newDiceValue);
            int newScore = _diceWithDeath.GetScore();
            Assert.AreEqual(oldScore, newScore);
        }
    }
}
