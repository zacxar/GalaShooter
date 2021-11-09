using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class Player
    {
        public string playerName { get; set; }
        public string[] playerShip { get; set; }
        public int playerHP { get; set; }
        public int posLeft { get; set; }
        public int posTop { get; set; }
        public int score { get; set; }

        public Player()
        {
            posLeft = 46;
            posTop = 45;
            this.playerHP = 5;
            this.score = 0;

            playerShip = new string[] {
                    " __/\\__ ",
                    "/__¨¨__\\",
                    "  \\║║/  ",
                    "  ^  ^  "
            };
        }

        public void DrawPlayer()
        {
            for (int i = 0; i < playerShip.Length; i++)
            {
                Console.SetCursorPosition(posLeft, posTop + i);
                Console.Write(playerShip[i]);
            }
        }

        public void ClearPlayer()
        {
            for (int i = 0; i < playerShip.Length; i++)
            {
                Console.SetCursorPosition(posLeft, posTop + i);
                Console.Write(new String(' ', playerShip[i].Length));
            }
        }

        public void MovePlayer(GameInput input)
        {
            switch (input)
            {
                case GameInput.left:
                    if (posLeft > 4)
                    {
                        ClearPlayer();
                        posLeft -= 4;
                        DrawPlayer();
                    }
                    break;
                case GameInput.right:
                    if (posLeft < 90)
                    {
                        ClearPlayer();
                        posLeft += 4;
                        DrawPlayer();
                    }
                    break;
                default:
                    break;
            }
        }

        public void TakeHit()
        {
            if (playerHP > 0)
                playerHP--;
        }
    }
}
