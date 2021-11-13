using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class Player
    {
        public string playerName { get; set; }
        public string[] playerShip { get; private set; }
        public int playerHP { get; private set; }
        public int posLeft { get; private set; }
        public int posTop { get; private set; }
        public int score { get; set; }

        public Player()
        {
            this.playerShip = new string[]
            {
                "  __/┘└\\__  ",
                " /─ ¨  ¨ ─\\ ",
                "|__ _  _ __|",
                "   \\║__║/   ",
                "    ^  ^    "
            };

            this.posLeft = (Globals.WINDOW_WIDTH + 2 - playerShip[0].Length) / 2;
            this.posTop = 45;
            this.playerHP = 5;
            this.score = 0;

            //playerShip = new string[] {
            //        " __/\\__ ",
            //        "/__¨¨__\\",
            //        "  \\║║/  ",
            //        "  ^  ^  "
            //};
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
                    if (posLeft > 6)
                    {
                        ClearPlayer();
                        posLeft -= 6;
                        DrawPlayer();
                    }
                    break;
                case GameInput.right:
                    if (posLeft < 86)
                    {
                        ClearPlayer();
                        posLeft += 6;
                        DrawPlayer();
                    }
                    break;
                case GameInput.space:
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

        public void ResetPlayer()
        {
            this.posLeft = (Globals.WINDOW_WIDTH + 2 - playerShip[0].Length) / 2;
            this.posTop = 45;
            this.playerHP = 5;
            this.score = 0;
        }
    }
}
