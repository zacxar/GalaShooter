using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class PlayerMissile
    {
        public int posLeft { get; private set; }
        public int posTop { get; private set; }

        public PlayerMissile(int l, int t)
        {
            posLeft = l;
            posTop = t;
        }

        public void DrawMissile()
        {
            if (posLeft > 0 && posLeft < Globals.WINDOW_WIDTH + 1 && posTop > 3 && posTop < Globals.WINDOW_HEIGHT + 1)
            {
                Console.SetCursorPosition(posLeft, posTop);
                Console.Write('|');
            }
        }

        public void ClearMissile()
        {
            Console.SetCursorPosition(posLeft, posTop);
            Console.Write(' ');
        }

        public void MoveMissile()
        {
            if (posTop > 4)
            {
                posTop -= 2;
            }
        }
    }
}
