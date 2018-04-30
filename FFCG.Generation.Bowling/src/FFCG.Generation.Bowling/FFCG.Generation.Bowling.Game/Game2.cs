using System;
using System.Collections.Generic;

namespace FFCG.Generation.Bowling.Game
{
    public class Game2
    {
        private int _score;
        public void Roll(int pins)
        {
            _score += pins;
        }

        public int Score()
        {
            return _score;
        }
    }
}
