using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Domain
{
    public class BowlingGame
    {
        private List<int> rolls = new List<int>(21);

        public int currentRoll = 0;

        public int Score { 
            get {
                var score = 0;
                var rollIndex = 0;
                
                for (var frame = 0; frame != 10; frame++)
                {
                    bool isStrike = false;
                    isStrike = IsStrike(rollIndex);
                    if (isStrike) {
                        score += CalculateStrike(rollIndex);
                    }
                    else if (IsSpare(rollIndex))
                    {
                        score += CalculateSpare(rollIndex);
                    }
                    else
                    {
                        score += CalculateOpenFrame(rollIndex);
                    }

                    rollIndex += isStrike ? 1 : 2;
                }

                return score;
            } 
        }

        

        private int CalculateOpenFrame(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1];
        }

        private int CalculateSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private int CalculateStrike(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] + rolls[rollIndex + 2];
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        public void Roll(int pins) {
            rolls.Add(pins);
        }

    }
}
