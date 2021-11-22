using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class LeaderboardPosition
    {
        public string name { get; private set; }
        public int score { get; private set; }

        public LeaderboardPosition(string n, int s)
        {
            name = n;
            score = s;
        }
    }
}
