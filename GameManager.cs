using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameManager
    {
        private GameMenu gameMenu;
        private GameRender gameRender;
        private InputHandler inputHandler;
        private Player player;

        public GameManager()
        {
            gameMenu = new GameMenu();
            gameRender = new GameRender();
            inputHandler = new InputHandler();
            player = new Player();
        }

        public void GameStart()
        {
            gameRender.DrawBorders(0, 3);
            gameRender.DrawTitle(7, 0);
            gameRender.DrawMenu(gameMenu, 23, 27);
            gameRender.DrawChoiceArrows(gameMenu, 0, 23, 27);

            int choice = 0;

            while (true)
            {
                GameInput input = inputHandler.GetInput();

                switch (input)
                {
                    case GameInput.down:
                        choice = (gameMenu.currentPos + 1) % 3;
                        gameRender.DrawChoiceArrows(gameMenu, choice, 23, 27);
                        break;
                    case GameInput.up:
                        choice = (gameMenu.currentPos + 2) % 3;
                        gameRender.DrawChoiceArrows(gameMenu, choice, 23, 27);
                        break;
                    case GameInput.space:
                        switch (gameMenu.currentPos)
                        {
                            case 0: //rozpoczęcie gry
                                GameLoop();
                                break;
                            case 1: //wyświetlenie tablicy wyników
                                ShowLeaderboard();
                                break;
                            case 2: //wyjście z gry
                                System.Environment.Exit(0);
                                break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        //od 2,5 do 97, 59
        public void GameLoop()
        {
            gameRender.ClearScreen();
            player.DrawPlayer();

            while (true)
            {
                player.MovePlayer(inputHandler.GetInput());
            }
        }

        public void ShowLeaderboard()
        {

        }
    }
}
