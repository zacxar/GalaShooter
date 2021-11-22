using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameInfo
    {
        public string playerName { private get; set; }
        private int playerHp;
        public int score { get; private set; }
        private int destroyedEnemies;
        private int missedEnemies;

        public GameInfo ()
        {
            playerName = "";
            playerHp = 5;
            score = 0;
            destroyedEnemies = 0;
            missedEnemies = 0;
        }

        public void ShowGameInfo()
        {
            Console.SetCursorPosition(1, Globals.WINDOW_HEIGHT - 1);
            Console.Write(new String('▀', Globals.WINDOW_WIDTH));
            Console.SetCursorPosition(1, Globals.WINDOW_HEIGHT);
            Console.Write("PILOT NAME: " + playerName);
            Console.SetCursorPosition(12 + playerName.Length + 1, Globals.WINDOW_HEIGHT);
            Console.Write(" LIVES: ");
            DrawPlayerLives(playerHp);
            Console.SetCursorPosition(1, Globals.WINDOW_HEIGHT + 1);
            Console.Write("SCORE: " + score);
            Console.SetCursorPosition(1, Globals.WINDOW_HEIGHT + 2);
            Console.Write("DESTROYED ENEMIES: " + destroyedEnemies);
            Console.SetCursorPosition(1, Globals.WINDOW_HEIGHT + 3);
            Console.Write("MISSED ENEMIES: " + missedEnemies);
        }

        public void ResetGameInfo()
        {
            playerName = "";
            playerHp = 5;
            score = 0;
            destroyedEnemies = 0;
            missedEnemies = 0;
        }

        public void DrawPlayerLives(int hp)
        {
            playerHp = hp;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(12 + playerName.Length + 9, Globals.WINDOW_HEIGHT);
            for (int i = 0; i < playerHp; i++)
                Console.Write("O ");

            for (int i = 0; i < 5 - playerHp; i++)
                Console.Write("  ");

            Console.ResetColor();
        }

        public void IncreaseScore()
        {
            score++;
            Console.SetCursorPosition(8, Globals.WINDOW_HEIGHT + 1);
            Console.Write(score);
        }

        public void DecreaseScore()
        {
            if (score > 0)
            {
                score--;
                Console.SetCursorPosition(8, Globals.WINDOW_HEIGHT + 1);
                Console.Write(score);
            }
        }

        public void IncreaseDestroyedEnemies()
        {
            destroyedEnemies++;
            Console.SetCursorPosition(20, Globals.WINDOW_HEIGHT + 2);
            Console.Write(destroyedEnemies);
        }

        public void IncreaseMissedEnemies()
        {
            missedEnemies++;
            Console.SetCursorPosition(17, Globals.WINDOW_HEIGHT + 3);
            Console.Write(missedEnemies);
        }
    }
}
