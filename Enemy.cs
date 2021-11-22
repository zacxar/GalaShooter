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
        public int enemyHp { get; set; }
        public int posLeft { get; private set; }
        public int posTop { get; private set; }
        public string[] enemyShip { get; private set; }
        public int enemyShootTimer { get; set; }
        public int enemyTimeToShoot { get; set; }
        public int type { get; private set; }
        private int enemyMoveTimer;

        public Enemy()
        {
            enemyHp = 5;
            posLeft = 2;
            posTop = 4;
            enemyMoveTimer = 2;
            enemyShootTimer = 7;
            type = 0;

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
            enemyMoveTimer = 2;
            this.type = type;
            enemyShootTimer = 0;
            enemyTimeToShoot = 10;

            switch (type)
            {
                case 0:
                    enemyHp = 10;

                    enemyShip = new string[]
                    {
                        "  ________  ",
                        " / ¨¨¨¨¨¨ \\ ",
                        "|  _ == _  |",
                        "|─/ \\││/ \\─|",
                        "|/   ├┤   \\|"
                    };
                    break;
                case 1:
                    enemyHp = 8;

                    enemyShip = new string[]
                    {
                        "  ________  ",
                        " / ¨¨¨¨¨¨ \\ ",
                        "|  _ == _  |",
                        "|┌/ \\__/ \\┐|",
                        "|┤        ├|"
                    };
                    break;
                case 2:
                    enemyHp = 12;

                    enemyShip = new string[]
                    {
                        " __________ ",
                        "/  ¨¨¨¨¨¨  \\",
                        "|   =  =   |",
                        " \\ /╔══╗\\ / ",
                        "  \\┤    ├/  "
                    };
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
                enemyMoveTimer = 2;    
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