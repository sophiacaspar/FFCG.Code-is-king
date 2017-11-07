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

        }

        [TestMethod]
        public void Rolled_dice_result_should_be_six()
        {
            _dice = new Dice();
            int rolledDiceResult = _dice.RollDice(123);
            Assert.AreEqual(6, rolledDiceResult);
        }

        [TestMethod]
        public void Should_guess_higher_and_be_right()
        {
            _dice = new Dice();
            int previousDiceRestult = _dice.RollDice(321);
            int newDiceRestult = _dice.RollDice(123);
            bool checkIfGuessIsRight = _diceWithDeath.IsHigherGuessRight(previousDiceRestult, newDiceRestult);
            Assert.IsTrue(checkIfGuessIsRight);
        }

        [TestMethod]
        public void Should_guess_lower_and_be_wrong()
        {
            _dice = new Dice();
            int previousDiceRestult = _dice.RollDice(321);
            int newDiceRestult = _dice.RollDice(123);
            bool checkIfGuessIsRight = _diceWithDeath.IsLowerGuessRight(previousDiceRestult, newDiceRestult);
            Assert.IsFalse(checkIfGuessIsRight);
        }

        [TestMethod]
        public void Right_guess_should_increase_score_by_one()
        {
            _score.IncreaseScoreByOne();
        }

        [TestMethod]
        public void Should_guess_wrong_and_game_over()
        {
        }

        [TestMethod]
        public void Final_score_should_be_three()
        {
        }
    }
}
