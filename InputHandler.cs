using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class InputHandler
    {
        public GameInput GetInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.LeftArrow)
                    return GameInput.left;
                else if (key.Key == ConsoleKey.RightArrow)
                    return GameInput.right;
                else if (key.Key == ConsoleKey.DownArrow)
                    return GameInput.down;
                else if (key.Key == ConsoleKey.UpArrow)
                    return GameInput.up;
                else if (key.Key == ConsoleKey.Spacebar)
                    return GameInput.space;
                else if (key.Key == ConsoleKey.Escape)
                    return GameInput.exit;
                else if (key.Key == ConsoleKey.Enter)
                    return GameInput.enter;
            }

            return GameInput.none;
        }
    }
}
