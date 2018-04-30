using System;
using System.Collections.Generic;
using System.Text;

namespace FFCG.Generation.Bowling
{
    public class Game
    {
        private List<int> _rollHistory = new List<int>();
        private int _score;

        public void Roll(int pins)
        {
            _rollHistory.Add(pins);
        }

        private bool RollIsSpare(int roll)
        {
            return _rollHistory[roll] + _rollHistory[roll + 1] == 10;
        }

        private bool RollIsStrike(int roll)
        {
            return _rollHistory[roll] == 10;
        }

        public int GetScore()
        {
            int roll = 0;
            for (int i = 0; i < 10; i++)
            {
                if (RollIsStrike(roll))
                {
                    _score += 10 + _rollHistory[roll + 1] + _rollHistory[roll + 2];
                    roll += 1;
                }
                else if (RollIsSpare(roll))
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
