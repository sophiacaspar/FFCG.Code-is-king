using FFCG.Generation.Bowling;
using System;
using Xunit;

namespace FFCG.Generation.Bowling.Tests
{
    public class BowlingTests
    {
        private Game _game;
        public BowlingTests()
        {
            _game = new Game();
        }

        public void RollMany(int numberOfRolls, int numberOfPins)
        {
            for (var i = 0; i < numberOfRolls; i++)
            {
                _game.Roll(numberOfPins);
            }
        }

        public void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        public void RollStrike()
        {
            _game.Roll(10);
        }

        [Fact]
        public void Test_gutter_game()
        {
            RollMany(20, 0);
            Assert.Equal(0, _game.GetScore());
        }

        [Fact]
        public void Test_all_ones()
        {
            RollMany(20, 1);
            Assert.Equal(20, _game.GetScore());
        }

        [Fact]
        public void Test_one_spare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17,0);
            Assert.Equal(16, _game.GetScore());
        }

        //[Fact]
        //public void Test_two_spares_in_a_row()
        //{
        //    RollSpare();
        //    RollSpare();
        //    _game.Roll(3);
        //    RollMany(15,0);
        //    Assert.Equal(31, _game.score);
        //}

        //[Fact]
        //public void Test_one_strike()
        //{
        //    RollStrike();
        //    _game.Roll(3);
        //    _game.Roll(4);
        //    RollMany(16,0);
        //    Assert.Equal(24, _game.score);
        }

        //[Fact]
        //public void Test_two_strikes_in_a_row()
        //{
        //    RollStrike();
        //    RollStrike();
        //    _game.Roll(3);
        //    _game.Roll(4);
        //    RollMany(14, 0);
        //    Assert.Equal(47, _game.score);
        //}
    }
}
