using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Domain
{
    public class Game
    {
        public IList<Frame> Frames { get; set; }
        public int Score { get; private set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public int CalculateScore()
        {
            Score = 0;
            for (var iFrame= 0; iFrame != 10; iFrame++) {
                var currentFrame = Frames[iFrame];
                var isStrike = currentFrame.IsStrike();
                if (isStrike)
                {
                    Score += currentFrame.Shots[0].PinsKnockedDown;
                    if (iFrame < 9)
                    {
                        Score += Frames[iFrame + 1].Shots.FirstOrDefault().PinsKnockedDown;
                        if (Frames[iFrame + 1].IsStrike())
                        {
                            Score += Frames[iFrame + 2].Shots.FirstOrDefault().PinsKnockedDown;
                        }
                        else Score += Frames[iFrame + 1].Shots.LastOrDefault().PinsKnockedDown;
                    }
                    else {
                        Score += Frames[iFrame].Shots[1].PinsKnockedDown + Frames[iFrame].Shots[2].PinsKnockedDown; //last frame, 3rd shot
                    }
                }
                else if (currentFrame.IsSpare()) {
                    Score += currentFrame.Shots[0].PinsKnockedDown + currentFrame.Shots[1].PinsKnockedDown;
                    if (iFrame < 9)
                    {
                        Score += Frames[iFrame + 1].Shots.FirstOrDefault().PinsKnockedDown;
                    }
                    else
                    {
                        Score += Frames[iFrame].Shots.LastOrDefault().PinsKnockedDown; //last frame, 3rd shot
                    }
                }
                else if (currentFrame.IsOpenFrame())
                {
                    if (iFrame < 9)
                        Score += currentFrame.Shots[0].PinsKnockedDown + currentFrame.Shots[1].PinsKnockedDown;
                    else 
                        Score += currentFrame.Shots[0].PinsKnockedDown + currentFrame.Shots[1].PinsKnockedDown + currentFrame.Shots[2].PinsKnockedDown;
                }
                else throw new IndexOutOfRangeException();
            }
            return Score;
        }
    }
}