﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameWindow
    {
        private string[] title;

        private string[] nameChoice;

        public GameWindow()
        {
            this.title = new string[] {
                " _____   _____          _____   _____  _     _  _____   _____  _______  ______  ______",
                "|  ____ |_____| |      |_____|  \\____  |_____| |     | |     |    |    |______ |_____/",
                "|_____| |     | |_____ |     |  _____| |     | |_____| |_____|    |    |______ |    \\_"
            };

            this.nameChoice = new string[] {
            " ___ _  _  __   __   ___  ___    _   _  __  _  _  ___    _  _  __  _  _  ___",
            "|    |__| |  | |  | [__  |___     \\_/  |  | |  | |__/    |\\ | |__| |\\/| |___",
            "|___ |  | |__| |__| ___] |___      |   |__| |__| |  \\    | \\| |  | |  | |___"
            };
        }

        public void DrawBorders(int left, int top)
        {
            Console.SetCursorPosition(left, top);

            for (int i = 0; i < Globals.WINDOW_WIDTH + 2; i++)
                Console.Write('▄');

            for (int i = 1; i < Globals.WINDOW_HEIGHT + 1; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write('█');
                Console.SetCursorPosition(left + Globals.WINDOW_WIDTH + 1, top + i);
                Console.Write('█');
            }

            Console.SetCursorPosition(left, top + Globals.WINDOW_HEIGHT + 1);

            for (int i = 0; i < Globals.WINDOW_WIDTH + 2; i++)
                Console.Write('▀');
        }

        public void DrawTitle()
        {
            int t = 0;
            for (int i = 0; i < title.Length; i++)
            {
                Console.SetCursorPosition((Globals.WINDOW_WIDTH + 2 - title[0].Length) / 2, t);
                Console.Write(title[i]);
                t++;
            }
        }

        public void ClearScreen()
        {
            for (int i = 4; i < Globals.WINDOW_HEIGHT; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write(new String(' ', Globals.WINDOW_WIDTH));
            }
        }

        public void DrawNameChoiceMenu()
        {
            int height = nameChoice.Length;
            int width = nameChoice[0].Length;
            int left = (Globals.WINDOW_WIDTH + 2 - width) / 2;
            int top = (Globals.WINDOW_HEIGHT - height) / 2;
            int s = nameChoice[0].Length / 2;

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < nameChoice.Length; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(nameChoice[i]);
                top++;
            }
            Console.ResetColor();

            Console.SetCursorPosition(left, top + 2);
            Console.Write("YOUR NAME: ");
        }
    }
}
