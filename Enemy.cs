using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;

namespace GalaShooter
{
    class Enemy
    {
        public int enemyHp { get; private set; }
        public int posLeft { get; private set; }
        public int posTop { get; private set; }
        public string[] enemyShip { get; private set; }
        public int enemyShootTimer { get; set; }
        public int enemyMoveTimer { get; set; }

        public Enemy()
        {
            enemyHp = 5;
            posLeft = 2;
            posTop = 4;

            enemyShip = new string[]
            {
                "  ________  ",
                " / ¨¨¨¨¨¨ \\ ",
                "|  _ ≡≡ _  |",
                "|─/ \\││/ \\─|",
                "|/   ├┤   \\|"
            };
        }

        public Enemy(int type, int l, int t)
        {
            posLeft = l;
            posTop = t;
            enemyMoveTimer = 1;

            switch (type)
            {
                case 0:
                    enemyHp = 5;

                    enemyShip = new string[]
                    {
                        "  ________  ",
                        " / ¨¨¨¨¨¨ \\ ",
                        "|  _ == _  |",
                        "|─/ \\││/ \\─|",
                        "|/   ├┤   \\|"
                    };
                    enemyShootTimer = 10;
                    break;
                case 1:
                    enemyHp = 3;

                    enemyShip = new string[]
                    {
                        "  ________  ",
                        " / ¨¨¨¨¨¨ \\ ",
                        "|  _ == _  |",
                        "|┌/ \\__/ \\┐|",
                        "|┤        ├|"
                    };
                    enemyShootTimer = 5;
                    break;
                case 2:
                    enemyHp = 10;

                    enemyShip = new string[]
                    {
                        " __________ ",
                        "/  ¨¨¨¨¨¨  \\",
                        "|   =  =   |",
                        " \\ /╔══╗\\ / ",
                        "  \\┤    ├/  "
                    };
                    enemyShootTimer = 15;
                    break;
            }
        }

        public void DrawEnemy()
        {
            for (int i = 0; i < enemyShip.Length; i++)
            {
                Console.SetCursorPosition(posLeft, posTop + i);
                Console.Write(enemyShip[i]);
            }
        }

        public void ClearEnemy()
        {
            for (int i = 0; i < enemyShip.Length; i++)
            {
                Console.SetCursorPosition(posLeft, posTop + i);
                Console.Write(new String(' ', enemyShip[i].Length));
            }
        }

        public void MoveEnemy()
        {
            if (enemyMoveTimer == 0 && posTop < Globals.WINDOW_HEIGHT + 1 - 2)
            {
                posTop += 1;
                enemyMoveTimer = 1;    
            }
            else
            {
                enemyMoveTimer--;
            }
            
        }

        public void TakeHit()
        {
            if (enemyHp > 0)
                enemyHp--;
        }
    }
}