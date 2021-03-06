using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class PlayerMissile
    {
        public int posLeft { get; protected set; }
        public int posTop { get; protected set; }

        protected char symbol;

        public PlayerMissile(int l, int t)
        {
            posLeft = l;
            posTop = t;
            symbol = '|';
        }

        public virtual void DrawMissile()
        {
            if (posLeft > 0 && posLeft < Globals.WINDOW_WIDTH + 1 && posTop > 3 && posTop < Globals.WINDOW_HEIGHT + 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(posLeft, posTop);
                Console.Write(symbol);
                Console.ResetColor();
            }
        }

        public virtual void ClearMissile()
        {
            Console.SetCursorPosition(posLeft, posTop);
            Console.Write(' ');
        }

        public virtual void MoveMissile()
        {
            posTop -= 2;
        }
    }
}
