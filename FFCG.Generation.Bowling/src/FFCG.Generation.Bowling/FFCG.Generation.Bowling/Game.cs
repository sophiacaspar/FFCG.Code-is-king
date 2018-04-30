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
            _currentRoll += 1;
            _rollHistory.Add(pins);

            //if (_currentRoll % 2 == 0)
            //{
            //    if (_rollHistory[_currentRoll -2] + pins == 10)
            //    {
            //        _spare = true;
            //    }
            //    else if (_strike)
            //    {
            //        UpdateScore(10 + (pins + _rollHistory[_currentRoll -2])*2);
            //        _strike = false;
            //    }
            //    else
            //    {
            //        UpdateScore(pins + _rollHistory[_currentRoll - 2]);
            //    }
            //}
            //else
            //{
            //    if (pins == 10)
            //    {
            //        _strike = true;
            //        _rollHistory.Add(0);
            //        _currentRoll += 1;
            //    }

            //    if (_spare)
            //    {
            //        UpdateScore(10 + pins);
            //        _spare = false;
            //    }
            //}
        }

        public void UpdateScore(int newScore)
        {
            score += newScore;
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
