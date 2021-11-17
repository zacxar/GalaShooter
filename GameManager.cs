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
                    case GameInput.enter:
                        switch (gameMenu.currentPos)
                        {
                            case 0: //rozpoczęcie gry
                                NameChoiceMenu();
                                Tutorial();
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

            Random rnd = new Random();
            int enemiesSpawnTimer = 0;
            int timeToSpawnNextEnemy = rnd.Next(50, 76);
            List<PlayerMissile> playerMissiles = new List<PlayerMissile>();
            List<Enemy> enemies = new List<Enemy>();

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
                        if (player.playerShootTimer == 5)
                        {
                            playerMissiles.Add(new PlayerMissile(player.posLeft + 5, player.posTop - 2));
                            playerMissiles.Add(new PlayerMissile(player.posLeft + 6, player.posTop - 2));
                            player.playerShootTimer = 0;
                        }
                        break;
                    case GameInput.exit:
                        return;
                        break;
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].ClearEnemy();
                    enemies[i].MoveEnemy();
                    enemies[i].DrawEnemy();
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].enemyHp == 0 || enemies[i].posTop == Globals.WINDOW_HEIGHT - 1)
                    {
                        enemies[i].DrawEnemy();
                        enemies[i].ClearEnemy();
                        enemies.RemoveAt(i);
                    }
                }

                for (int i = 0; i < playerMissiles.Count; i++)
                {
                    playerMissiles[i].ClearMissile();
                    playerMissiles[i].MoveMissile();
                    playerMissiles[i].DrawMissile();
                }

                for (int i = 0; i < playerMissiles.Count; i++)
                {
                    if (playerMissiles[i].posTop <= 4)
                    {
                        playerMissiles[i].DrawMissile();
                        playerMissiles[i].ClearMissile();
                        playerMissiles.RemoveAt(i);
                    }
                }

                if (enemiesSpawnTimer != timeToSpawnNextEnemy)
                    enemiesSpawnTimer++;
                else
                {
                    int l = rnd.Next(0, 15);

                    enemies.Add(new Enemy(rnd.Next(0, 3), 2 + l * 6, 4));

                    enemiesSpawnTimer = 0;
                    timeToSpawnNextEnemy= rnd.Next(50, 76);
                }

                if (player.playerShootTimer != 5)
                    player.playerShootTimer++;

                System.Threading.Thread.Sleep(50);
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

        public void Tutorial()
        {
            gameWindow.ClearScreen();
            gameWindow.DrawTutorial();
            Console.ReadKey();
        }

        public void ShowLeaderboard()
        {

        }
    }
}
