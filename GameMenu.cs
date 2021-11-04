using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameMenu
    {
        public int currentPos { get; set; }

        private string[,] menuOptions = {
                { "____ ___ ____ ____ ___",
                  "[__   |  |__| |__/  | ",
                  "___]  |  |  | |  \\  | " },

                { "_    ____ ____ ___  ____ ____ ___  ____ ____ ____ ___ ",
                  "|    |___ |__| |  \\ |___ |__/ |__] |  | |__| |__/ |  \\",
                  "|___ |___ |  | |__/ |___ |  \\ |__] |__| |  | |  \\ |__/" },

                { "____ _  _ _ ___",
                  "|___  \\/  |  | ",
                  "|___ _/\\_ |  | " }
        };

        public GameMenu()
        {
            currentPos = 0;
        }

        public void DrawMenu(int left, int top)
        {
            int t = top;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == currentPos)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(left + (27 - menuOptions[i, j].Length / 2) - 4, t + i * 3);
                        Console.Write("_");
                        Console.SetCursorPosition(left + (27 - menuOptions[i, j].Length / 2) - 5, t + 1 + i * 3);
                        Console.Write("| \\");
                        Console.SetCursorPosition(left + (27 - menuOptions[i, j].Length / 2) - 5, t + 2 + i * 3);
                        Console.Write("|_/");

                        Console.SetCursorPosition(left + (27 + menuOptions[i, j].Length / 2) + 3, t + i * 3);
                        Console.Write("_");
                        Console.SetCursorPosition(left + (27 + menuOptions[i, j].Length / 2) + 2, t + 1 + i * 3);
                        Console.Write("/ |");
                        Console.SetCursorPosition(left + (27 + menuOptions[i, j].Length / 2) + 2, t + 2 + i * 3);
                        Console.Write("\\_|");

                        Console.ResetColor();
                    }

                    Console.SetCursorPosition(left + (27 - menuOptions[i, j].Length / 2), t + j + i * 3);
                    Console.Write(menuOptions[i, j]);
                }

                t += 1;
            }
        }
    }
}
