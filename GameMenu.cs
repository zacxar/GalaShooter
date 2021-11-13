using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameMenu
    {
        public int currentPos { get; set; }

        private string[,] menuOptions;

        private int menuHeight;
        private int menuWidth;

        public GameMenu()
        {
            this.menuOptions = new string[,] {
                { " ___ ___  __   ___ ___",
                  "[__   |  |__| |__/  | ",
                  "___]  |  |  | |  \\  | " },

                { "      ___  __   __   ___  ___  __   __   __   ___  __ ",
                  "|    |___ |__| |  \\ |___ |__/ |__] |  | |__| |__/ |  \\",
                  "|___ |___ |  | |__/ |___ |  \\ |__] |__| |  | |  \\ |__/" },

                { " ___ _  _ _ ___",
                  "|___  \\/  |  | ",
                  "|___ _/\\_ |  | " }
            };

            this.currentPos = 0;
            this.menuHeight = menuOptions.Length + menuOptions.GetLength(0) - 1; ;
            this.menuWidth = menuOptions[1, 0].Length;
        }

        public void DrawMenu()
        {
            int left = (Globals.WINDOW_WIDTH - menuWidth) / 2 + 1;
            int top = (Globals.WINDOW_HEIGHT - menuHeight) / 2 + 4;
            int s = menuWidth / 2;

            for (int i = 0; i < menuOptions.GetLength(0); i++)
            {
                for (int j = 0; j < menuOptions.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left + (s - menuOptions[i, j].Length / 2), top + j + i * 3);
                    Console.Write(menuOptions[i, j]);
                }

                top += 1;
            }
        }

        public void DrawChoiceArrows(int choice)
        {
            currentPos = choice;
            int left = (Globals.WINDOW_WIDTH - menuWidth) / 2 + 1;
            int top = (Globals.WINDOW_HEIGHT - menuHeight) / 2 + 4 + currentPos * 4;
            int s = menuOptions[1, 0].Length / 2;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 4, top);
            Console.Write("_");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, top + 1);
            Console.Write("| \\");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, top + 2);
            Console.Write("|_/");

            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 3, top);
            Console.Write("_");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, top + 1);
            Console.Write("/ |");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, top + 2);
            Console.Write("\\_|");

            Console.ResetColor();
        }

        public void ClearChoiceArrows()
        {
            int left = (Globals.WINDOW_WIDTH - menuWidth) / 2 + 1;
            int top = (Globals.WINDOW_HEIGHT - menuHeight) / 2 + 4 + currentPos * 4;
            int s = menuOptions[1, 0].Length / 2;

            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 4, top);
            Console.Write(" ");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, top + 1);
            Console.Write("   ");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, top + 2);
            Console.Write("   ");

            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 3, top);
            Console.Write(" ");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, top + 1);
            Console.Write("   ");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, top + 2);
            Console.Write("   ");
        }
    }
}
