using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class Game
    {
        string[] title = {
                " _____   _____          _____   _____  _     _  _____   _____  _______  ______  ______",
                "|  ____ |_____| |      |_____|  \\____  |_____| |     | |     |    |    |______ |_____/",
                "|_____| |     | |_____ |     |  _____| |     | |_____| |_____|    |    |______ |    \\_"
        };

        public void GameLoop(int left, int top)
        {

        }

        public void GameMenu(int left, int top)
        {

        }

        public void DrawBorders(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            
            for (int i = 0; i < 100; i++)
                Console.Write('▄');

            for (int i = 1; i < 59; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write('█');
                Console.SetCursorPosition(left + 99, top + i);
                Console.Write('█');
            }

            Console.SetCursorPosition(left, top + 59);
            
            for (int i = 0; i < 100; i++)
                Console.Write('▀');

        }

        public void DrawTitle(int left, int top)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(title[i]);
                top++;
            }
        }
    }
}
