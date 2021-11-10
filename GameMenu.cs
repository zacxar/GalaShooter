using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameMenu
    {
        public int currentPos { get; set; }

        private string[,] menuOptions = {
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

        public GameMenu()
        {
            this.currentPos = 0;
        }

        public void DrawMenu(int left, int top)
        {
            int t = top;
            int s = menuOptions[1, 0].Length / 2;

            for (int i = 0; i < menuOptions.GetLength(0); i++)
            {
                for (int j = 0; j < menuOptions.GetLength(1); j++)
                {
                    Console.SetCursorPosition(left + (s - menuOptions[i, j].Length / 2), t + j + i * 3);
                    Console.Write(menuOptions[i, j]);
                }

                t += 1;
            }
        }

        public void DrawChoiceArrows(int choice, int left, int top)
        {
            currentPos = choice;
            int t = top + currentPos * 4;
            int s = menuOptions[1, 0].Length / 2;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 4, t);
            Console.Write("_");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, t + 1);
            Console.Write("| \\");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, t + 2);
            Console.Write("|_/");

            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 3, t);
            Console.Write("_");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, t + 1);
            Console.Write("/ |");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, t + 2);
            Console.Write("\\_|");

            Console.ResetColor();
        }

        public void ClearChoiceArrows(int left, int top)
        {
            int t = top + currentPos * 4;
            int s = menuOptions[1, 0].Length / 2;

            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 4, t);
            Console.Write(" ");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, t + 1);
            Console.Write("   ");
            Console.SetCursorPosition(left + (s - menuOptions[currentPos, 0].Length / 2) - 5, t + 2);
            Console.Write("   ");

            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 3, t);
            Console.Write(" ");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, t + 1);
            Console.Write("   ");
            Console.SetCursorPosition(left + (s + menuOptions[currentPos, 0].Length / 2) + 2, t + 2);
            Console.Write("   ");
        }
    }
}
