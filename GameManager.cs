using System;
using System.Collections.Generic;
using System.Text;

namespace GalaShooter
{
    class GameManager
    {
        private GameMenu gameMenu;
        private GameWindow gameWindow;
        private InputHandler inputHandler;
        private Player player;

        public GameManager()
        {
            this.gameMenu = new GameMenu();
            this.gameWindow = new GameWindow();
            this.inputHandler = new InputHandler();
            this.player = new Player();
        }

        public void GameStart()
        {
            gameWindow.DrawBorders(0, 3);
            gameWindow.DrawTitle(7, 0);
            GameMenuLoop();
        }

        public void GameMenuLoop()
        {
            gameWindow.ClearScreen();
            gameMenu.DrawMenu(23, 27);
            gameMenu.DrawChoiceArrows(0, 23, 27);

            int choice = 0;

            while (true)
            {
                GameInput input = inputHandler.GetInput();

                switch (input)
                {
                    case GameInput.down:
                        choice = (gameMenu.currentPos + 1) % 3;
                        gameMenu.ClearChoiceArrows(23, 27);
                        gameMenu.DrawChoiceArrows(choice, 23, 27);
                        break;
                    case GameInput.up:
                        choice = (gameMenu.currentPos + 2) % 3;
                        gameMenu.ClearChoiceArrows(23, 27);
                        gameMenu.DrawChoiceArrows(choice, 23, 27);
                        break;
                    case GameInput.space:
                        switch (gameMenu.currentPos)
                        {
                            case 0: //rozpoczęcie gry
                                GameLoop();
                                gameWindow.ClearScreen();
                                gameMenu.DrawMenu(23, 27);
                                gameMenu.DrawChoiceArrows(choice, 23, 27);
                                break;
                            case 1: //wyświetlenie tablicy wyników
                                ShowLeaderboard();
                                gameWindow.ClearScreen();
                                gameMenu.DrawMenu(23, 27);
                                gameMenu.DrawChoiceArrows(choice, 23, 27);
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
            gameWindow.ClearScreen();

            player.ResetPlayer();
            player.DrawPlayer();

            while (true)
            { 
                GameInput input = inputHandler.GetInput();

                switch (input)
                {
                    case GameInput.left:
                        player.MovePlayer(input);
                        break;
                    case GameInput.right:
                        player.MovePlayer(input);
                        break;
                    case GameInput.space:
                        break;
                    case GameInput.exit:
                        return;
                        break;
                }
            }
        }

        public void ShowLeaderboard()
        {

        }
    }
}
