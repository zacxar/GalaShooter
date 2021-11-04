using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class Game
    {
        private GameMenu gameMenu;
        private GameRender gameRender;

        public Game()
        {
            gameMenu = new GameMenu();
            gameRender = new GameRender();
        }

        public void GameLoop()
        {
            gameRender.DrawBorders(0, 3);
            gameRender.DrawTitle(7, 0);
            gameRender.DrawMenu(gameMenu, 23, 27);
        }
    }
}
