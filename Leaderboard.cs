using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace GalaShooter
{
    class Leaderboard
    {
        private string path;
        private string[] leaderboardTitle;
        private List<LeaderboardPosition> leaderboardList;

        public Leaderboard()
        {
            path = "leaderboard.txt";
            leaderboardList = new List<LeaderboardPosition>();
            leaderboardTitle = new string[]
            {
                "_     ___  __   __   ___  ___  __   __   __   ___  __ ",
                "|    |___ |__| |  \\ |___ |__/ |__] |  | |__| |__/ |  \\",
                "|___ |___ |  | |__/ |___ |  \\ |__] |__| |  | |  \\ |__/"
            };
        }

        public void DrawLeaderboard()
        {
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
            leaderboardList = new List<LeaderboardPosition>();
            StreamReader streamReader = new StreamReader(path);
            string line;    
            string[] s = new string[2];
            while((line = streamReader.ReadLine()) != null)
            {
                s = line.Split(' ');
                leaderboardList.Add(new LeaderboardPosition(s[0], Int32.Parse(s[1])));
            }

            streamReader.Close();

            int height = leaderboardTitle.Length;
            int width = leaderboardTitle[0].Length;
            int left = (Globals.WINDOW_WIDTH + 2 - width) / 2;
            int top = (Globals.WINDOW_HEIGHT - (height + 20)) / 2;

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < leaderboardTitle.Length; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(leaderboardTitle[i]);
                top++;
            }
            Console.ResetColor();

            top++;
            for (int i = 0; i < leaderboardList.Count; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(i + 1 + ". " + leaderboardList[i].name);
                Console.SetCursorPosition(left + 21, top);
                Console.Write(leaderboardList[i].score);
                top += 2;
            }

            for (int i = leaderboardList.Count; i < 10; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(i + 1 + ".");
                top += 2;
            }
        }

        public void AddToLeaderboard(string name, int score)
        {
            for (int i = 0; i < leaderboardList.Count; i++)
            {
                if (score > leaderboardList[i].score)
                {
                    leaderboardList.Insert(i, new LeaderboardPosition(name, score));
                    break;
                }
                else if (i == leaderboardList.Count - 1)
                {
                    leaderboardList.Add(new LeaderboardPosition(name, score));
                    break;
                }
                else if (score <= leaderboardList[i].score)
                    continue;
            }

            if (leaderboardList.Count == 0)
                leaderboardList.Add(new LeaderboardPosition(name, score));

            if (leaderboardList.Count > 10)
                leaderboardList.RemoveRange(10, leaderboardList.Count - 10);

            StreamWriter streamWriter = File.CreateText(path);

            for(int i = 0; i < leaderboardList.Count; i++)
            {
                streamWriter.WriteLine(leaderboardList[i].name + " " + leaderboardList[i].score.ToString());
            }

            streamWriter.Close();
        }
    }
}
