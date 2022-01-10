using System.Collections.Generic;
using System.Linq;

namespace Bowling.Domain
{
    public class Frame
    {
        public IList<Shot> Shots { get; set; }

        public bool IsOpenFrame() {
            if (Shots.Count > 1 && (Shots[0].PinsKnockedDown + Shots[1].PinsKnockedDown) < 10) return true;
            else return false;
        }

        internal bool IsStrike()
        {
            if (Shots.Count > 0 && Shots.FirstOrDefault().PinsKnockedDown == 10) return true;
            else return false;
        }

        internal bool IsSpare()
        {
            if (Shots.Count > 1 && (Shots[0].PinsKnockedDown + Shots[1].PinsKnockedDown) == 10) return true;
            else return false;
        }
    }
}