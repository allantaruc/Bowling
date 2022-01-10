using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bowling.Domain
{
    public class Game
    {
        public IList<Frame> Frames { get; set; }
        public int Score { get; private set; }

        public int CalculateScore()
        {
            Score = 0;
            for (var iFrame= 0; iFrame != 10; iFrame++) {
                var currentFrame = Frames[iFrame];
                var isStrike = currentFrame.IsStrike();
                if (isStrike)
                {
                    Score += currentFrame.Shots[0].PinsKnocked;
                    if (iFrame < 9)
                    {
                        Score += Frames[iFrame + 1].Shots.FirstOrDefault().PinsKnocked;
                        if (Frames[iFrame + 1].IsStrike())
                        {
                            Score += Frames[iFrame + 2].Shots.FirstOrDefault().PinsKnocked;
                        }
                        else Score += Frames[iFrame + 1].Shots.LastOrDefault().PinsKnocked;
                    }
                    else {
                        Score += Frames[iFrame].Shots[1].PinsKnocked + Frames[iFrame].Shots[2].PinsKnocked; //last frame, 3rd shot
                    }
                }
                else if (currentFrame.IsSpare()) {
                    Score += currentFrame.Shots[0].PinsKnocked + currentFrame.Shots[1].PinsKnocked;
                    if (iFrame < 9)
                    {
                        Score += Frames[iFrame + 1].Shots.FirstOrDefault().PinsKnocked;
                    }
                    else
                    {
                        Score += Frames[iFrame].Shots.LastOrDefault().PinsKnocked; //last frame, 3rd shot
                    }
                }
                else if (currentFrame.IsOpenFrame())
                {
                    if (iFrame < 9)
                        Score += currentFrame.Shots[0].PinsKnocked + currentFrame.Shots[1].PinsKnocked;
                    else 
                        Score += currentFrame.Shots[0].PinsKnocked + currentFrame.Shots[1].PinsKnocked + currentFrame.Shots[2].PinsKnocked;
                }
                else throw new IndexOutOfRangeException();
            }
            return Score;
        }
    }
}