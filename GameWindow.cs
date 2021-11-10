using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameWindow
    {
        private string[] title = {
                " _____   _____          _____   _____  _     _  _____   _____  _______  ______  ______",
                "|  ____ |_____| |      |_____|  \\____  |_____| |     | |     |    |    |______ |_____/",
                "|_____| |     | |_____ |     |  _____| |     | |_____| |_____|    |    |______ |    \\_"
        };

        public void DrawBorders(int left, int top)
        {
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < 100; i++)
                Console.Write('▄');

            for (int i = 1; i < 58; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write('█');
                Console.SetCursorPosition(left + 99, top + i);
                Console.Write('█');
            }

            Console.SetCursorPosition(left, top + 58);

            for (int i = 0; i < 100; i++)
                Console.Write('▀');

        }

        public void DrawTitle(int left, int top)
        {
            for (int i = 0; i < title.Length; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(title[i]);
                top++;
            }
        }

        public void ClearScreen()
        {
            for (int i = 4; i < 61; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new String(' ', 98));
            }
        }
    }
}
