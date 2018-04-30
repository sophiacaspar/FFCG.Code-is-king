using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Generation.Bowling
{
    public class Game
    {
        public int score;
        private bool _spare = false;
        private bool _strike;
        private int _currentRoll;
        private List<int> _rollHistory = new List<int>();
        private int _score;


        public void Roll(int pins)
        {
            _rollHistory.Add(pins);
        }

        public int GetScore()
        {
            int roll = 0;
            for (int i = 0; i < 10; i++)
            {
                if (_rollHistory[roll] == 10)
                {
                    _score += 10 + _rollHistory[roll + 1] + _rollHistory[roll + 2];
                    roll += 1;
                }
                else if (_rollHistory[roll] + _rollHistory[roll + 1] == 10)
                {
                    _score += 10 + _rollHistory[roll + 2];
                    roll += 2;
                }
                else
                {
                    _score += _rollHistory[roll] + _rollHistory[roll + 1];
                    roll += 2;
                }
            }

            return _score;
        }
    }
}
