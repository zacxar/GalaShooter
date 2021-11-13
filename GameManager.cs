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
            gameWindow.DrawTitle();
            GameMenuLoop();
        }

        public void GameMenuLoop()
        {
            gameWindow.ClearScreen();
            gameMenu.DrawMenu();
            gameMenu.DrawChoiceArrows(0);

            int choice = 0;

            while (true)
            {
                GameInput input = inputHandler.GetInput();

                switch (input)
                {
                    case GameInput.down:
                        choice = (gameMenu.currentPos + 1) % 3;
                        gameMenu.ClearChoiceArrows();
                        gameMenu.DrawChoiceArrows(choice);
                        break;
                    case GameInput.up:
                        choice = (gameMenu.currentPos + 2) % 3;
                        gameMenu.ClearChoiceArrows();
                        gameMenu.DrawChoiceArrows(choice);
                        break;
                    case GameInput.space:
                        switch (gameMenu.currentPos)
                        {
                            case 0: //rozpoczęcie gry
                                NameChoiceMenu();
                                GameLoop();
                                gameWindow.ClearScreen();
                                gameMenu.DrawMenu();
                                gameMenu.DrawChoiceArrows(choice);
                                break;
                            case 1: //wyświetlenie tablicy wyników
                                ShowLeaderboard();
                                gameWindow.ClearScreen();
                                gameMenu.DrawMenu();
                                gameMenu.DrawChoiceArrows(choice);
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

        public void NameChoiceMenu()
        {
            player.ResetPlayer();
            gameWindow.ClearScreen();
            gameWindow.DrawNameChoiceMenu();

            Console.CursorVisible = true;
            string name = Console.ReadLine();
            player.playerName = name;
            Console.CursorVisible = false;
        }

        public void ShowLeaderboard()
        {

        }
    }
}
