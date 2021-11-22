using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameWindow
    {
        private string[] title;
        public string[] nameChoice { get; private set; }
        private string[] tutorial;
        private string[] pause;
        private string[] gameOver;

        public GameWindow()
        {
            title = new string[] {
                " _____   _____  _       _____   _____  _     _  _____   _____  _______  ______  ______",
                "|  ____ |_____| |      |_____|  \\____  |_____| |     | |     |    |    |______ |_____/",
                "|_____| |     | |_____ |     |  _____| |     | |_____| |_____|    |    |______ |    \\_"
            };

            nameChoice = new string[] {
                " ___ _  _  __   __   ___  ___    _   _  __  _  _  ___    _  _  __  _  _  ___",
                "|    |__| |  | |  | [__  |___     \\_/  |  | |  | |__/    |\\ | |__| |\\/| |___",
                "|___ |  | |__| |__| ___] |___      |   |__| |__| |  \\    | \\| |  | |  | |___"
            };

            tutorial = new string[]
            {
                "_ _  _  ___ ___  ___ _  _  ___ ___ _  __  _  _  ___",
                "| |\\ | [__   |  |__/ |  | |     |  | |  | |\\ | [__ ",
                "| | \\| ___]  |  |  \\ |__| |___  |  | |__| | \\| ___]"
            };

            pause = new string[]
            {
                " __   __  _  _  ___  ___",
                "|__] |__| |  | [__  |___",
                "|    |  | |__| ___] |___"
            };

            gameOver = new string[]
            {
                " ___  __  _  _  ___     __  _  _  ___  ___",
                "| __ |__| |\\/| |___    |  | |  | |___ |__/",
                "|__] |  | |  | |___    |__|  \\/  |___ |  \\"
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            int t = 0;
            for (int i = 0; i < title.Length; i++)
            {
                Console.SetCursorPosition((Globals.WINDOW_WIDTH + 2 - title[0].Length) / 2, t);
                Console.Write(title[i]);
                t++;
            }
            Console.ResetColor();
        }

        public void ClearScreen()
        {
            for (int i = 4; i < Globals.WINDOW_HEIGHT + 4; i++)
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
            Console.Write("GREETINGS PILOT, WHAT IS YOUR NAME?\n");
            Console.SetCursorPosition(left, top + 3);
        }

        public void DrawTutorial()
        {
            int height = tutorial.Length;
            int width = tutorial[0].Length;
            int left = (Globals.WINDOW_WIDTH + 2 - width) / 2;
            int top = (Globals.WINDOW_HEIGHT - height) / 2;
            int s = tutorial[0].Length / 2;

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < tutorial.Length; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(tutorial[i]);
                top++;
            }
            Console.ResetColor();

            Console.SetCursorPosition(left, top + 2);
            Console.Write("TO MOVE YOUR SHIP USE LEFT ARROW <- AND RIGHT ARROW ->");
            Console.SetCursorPosition(left, top + 3);
            Console.Write("TO SHOOT USE SPACEBAR");
            Console.SetCursorPosition(left, top + 4);
            Console.Write("TO PAUSE GAME USE ESC");
            Console.SetCursorPosition(left, top + 5);
            Console.Write("AVOID ENEMY MISSILES AND DESTROY ALL ENEMY SHIPS");
            Console.SetCursorPosition(left, top + 8);
            Console.Write("PRESS ANY KEY TO CONTINUE...");
        }

        public void DrawPause()
        {
            int width = pause[0].Length;
            int left = (Globals.WINDOW_WIDTH + 2 - width) / 2;
            int top = Globals.WINDOW_HEIGHT - 6;

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < pause.Length; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(pause[i]);
                top++;
            }
            Console.ResetColor();

            string instruction = "TO EXIT TO MAIN MENU PRESS ESC, TO CONTINUE GAME PRESS SPACEBAR";
            Console.SetCursorPosition((Globals.WINDOW_WIDTH + 2 - instruction.Length) / 2, Globals.WINDOW_HEIGHT - 2);
            Console.Write(instruction);
        }

        public void ClearPause()
        {
            int l = (Globals.WINDOW_WIDTH + 2 - pause[0].Length) / 2;
            int t = Globals.WINDOW_HEIGHT - 6;

            for (int i = 0; i < pause.Length; i++)
            {
                Console.SetCursorPosition(l, t);
                Console.Write(new String(' ', pause[i].Length));
                t++;
            }

            Console.SetCursorPosition(1, t + 1);
            Console.Write(new String(' ', Globals.WINDOW_WIDTH));
        }

        public void DrawGameOver(int score)
        {
            int width = gameOver[0].Length;
            int left = (Globals.WINDOW_WIDTH + 2 - width) / 2;
            int top = Globals.WINDOW_HEIGHT - 6;

            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < gameOver.Length; i++)
            {
                Console.SetCursorPosition(left, top);
                Console.Write(gameOver[i]);
                top++;
            }
            Console.ResetColor();

            string inscruction = "PRESS ESC TO EXIT TO MAIN MENU...";
            Console.SetCursorPosition(left, Globals.WINDOW_HEIGHT - 3);
            Console.Write("YOUR SCORE IS: " + score);
            Console.SetCursorPosition(left, Globals.WINDOW_HEIGHT - 2);
            Console.Write(inscruction);
        }
    }
}
