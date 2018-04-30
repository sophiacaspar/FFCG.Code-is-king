using System.Collections.Generic;

namespace FFCG.Generation.Bowling
{
    public class Game
    {
        private readonly List<int> _rollHistory = new List<int>();
        private int _score;

        public void Roll(int pins)
        {
            _rollHistory.Add(pins);
        }

        public int GetScore()
        {
            int roll = 0;
            for (int frame = 0; frame < 10; frame++)
            {
                if (RollIsStrike(roll))
                {
                    _score += 10 + GetStrikeBonus(roll);
                    roll += 1;
                }
                else if (RollIsSpare(roll))
                {
                    _score += 10 + GetSpareBonus(roll);
                    roll += 2;
                }
                else
                {
                    _score += GetSumOfRollsInFrame(roll);
                    roll += 2;
                }
            }

            return _score;
        }

        private bool RollIsSpare(int roll)
        {
            return _rollHistory[roll] + _rollHistory[roll + 1] == 10;
        }

        private bool RollIsStrike(int roll)
        {
            return _rollHistory[roll] == 10;
        }

        private int GetStrikeBonus(int roll)
        {
            return _rollHistory[roll + 1] + _rollHistory[roll + 2];
        }

        private int GetSpareBonus(int roll)
        {
            return _rollHistory[roll + 2];
        }

        private int GetSumOfRollsInFrame(int roll)
        {
            return _rollHistory[roll] + _rollHistory[roll + 1];
        }
    }
}
