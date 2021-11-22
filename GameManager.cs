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
        private GameInfo gameInfo;
        private Leaderboard leaderboard;
        private List<PlayerMissile> playerMissiles;
        private List<EnemyMissile> enemyMissiles;
        private List<Enemy> enemies;

        public GameManager()
        {
            gameMenu = new GameMenu();
            gameWindow = new GameWindow();
            inputHandler = new InputHandler();
            player = new Player();
            gameInfo = new GameInfo();
            leaderboard = new Leaderboard();
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
            int timeToSpawnNextEnemy = rnd.Next(20, 56);
            playerMissiles = new List<PlayerMissile>();
            enemyMissiles = new List<EnemyMissile>();
            enemies = new List<Enemy>();

            player.DrawPlayer();
            gameInfo.ShowGameInfo();

            while (player.playerHP > 0)
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
                        switch (Pause())
                        {
                            case true:
                                gameWindow.ClearPause();
                                for (int i = 0; i < enemies.Count; i++)
                                {
                                    enemies[i].ClearEnemy();
                                    enemies[i].DrawEnemy();
                                }
                                break;
                            case false:
                                gameWindow.ClearPause();
                                GameOver();
                                return;
                                break;
                        }
                        break;
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].enemyShootTimer != enemies[i].enemyTimeToShoot)
                        enemies[i].enemyShootTimer++;
                    else if (enemies[i].posTop < Globals.WINDOW_HEIGHT - 15)
                    {
                        switch (enemies[i].type)
                        {
                            case 0:
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft + 5, enemies[i].posTop + 6));
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft + 6, enemies[i].posTop + 6));
                                break;
                            case 1:
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft, enemies[i].posTop + 6));
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft + 11, enemies[i].posTop + 6));
                                break;
                            case 2:
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft + 4, enemies[i].posTop + 6));
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft + 5, enemies[i].posTop + 6));
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft + 6, enemies[i].posTop + 6));
                                enemyMissiles.Add(new EnemyMissile(enemies[i].posLeft + 7, enemies[i].posTop + 6));
                                break;
                        }

                        enemies[i].enemyShootTimer = 0;
                        enemies[i].enemyTimeToShoot = rnd.Next(15, 51);
                    }
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].posTop == Globals.WINDOW_HEIGHT - 6)
                    {
                        enemies[i].DrawEnemy();
                        enemies[i].ClearEnemy();
                        enemies.RemoveAt(i);

                        gameInfo.DecreaseScore();
                        gameInfo.IncreaseMissedEnemies();
                    }
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].ClearEnemy();
                    enemies[i].MoveEnemy();
                    enemies[i].DrawEnemy();
                }

                for (int i = 0; i < playerMissiles.Count; i++)
                {
                    if (playerMissiles[i].posTop <= 6)
                    {
                        playerMissiles[i].DrawMissile();
                        playerMissiles[i].ClearMissile();
                        playerMissiles.RemoveAt(i);
                    }
                }

                for (int i = 0; i < playerMissiles.Count; i++)
                {
                    playerMissiles[i].ClearMissile();
                    playerMissiles[i].MoveMissile();
                    playerMissiles[i].DrawMissile();
                }

                for (int i = 0; i < enemyMissiles.Count; i++)
                {
                    if (enemyMissiles[i].posTop >= Globals.WINDOW_HEIGHT - 5)
                    {
                        enemyMissiles[i].DrawMissile();
                        enemyMissiles[i].ClearMissile();
                        enemyMissiles.RemoveAt(i);
                    }
                }

                for (int i = 0; i < enemyMissiles.Count; i++)
                {
                    enemyMissiles[i].ClearMissile();
                    enemyMissiles[i].MoveMissile();
                    enemyMissiles[i].DrawMissile();
                }

                HandleCollisions();

                if (player.playerHP == 0)
                    GameOver();

                if (enemiesSpawnTimer != timeToSpawnNextEnemy)
                    enemiesSpawnTimer++;
                else
                {
                    int l = rnd.Next(0, 15);

                    enemies.Add(new Enemy(rnd.Next(0, 3), 2 + l * 6, 4));

                    enemiesSpawnTimer = 0;
                    timeToSpawnNextEnemy = rnd.Next(30, 56);
                }

                if (player.playerShootTimer != 5)
                    player.playerShootTimer++;

                System.Threading.Thread.Sleep(50);
            }
            return;
        }

        public void HandleCollisions()
        {
            for (int i = 0; i < playerMissiles.Count; i++)
            {
                int mLeft = playerMissiles[i].posLeft;
                int mTop = playerMissiles[i].posTop;
                for (int j = 0; j < enemies.Count; j++)
                {
                    if (mLeft >= enemies[j].posLeft && mLeft <= enemies[j].posLeft + enemies[j].enemyShip[0].Length - 1
                        && mTop <= enemies[j].posTop + enemies[j].enemyShip.Length && mTop >= enemies[j].posTop)
                    {
                        enemies[j].enemyHp--;
                        playerMissiles[i].DrawMissile();
                        playerMissiles[i].ClearMissile();
                        playerMissiles.RemoveAt(i);

                        if (enemies[j].enemyHp == 0)
                        {
                            enemies[j].DrawEnemy();
                            enemies[j].ClearEnemy();
                            enemies.RemoveAt(j);

                            gameInfo.IncreaseScore();
                            gameInfo.IncreaseDestroyedEnemies();
                        }
                    }
                }
            }

            for (int i = 0; i < enemyMissiles.Count; i++)
            {
                int mLeft = enemyMissiles[i].posLeft;
                int mTop = enemyMissiles[i].posTop;

                if (mLeft >= player.posLeft && mLeft <= player.posLeft + player.playerShip[0].Length - 1
                    && mTop <= player.posTop + player.playerShip.Length - 2 && mTop >= player.posTop)
                {
                    player.TakeHit();
                    gameInfo.DrawPlayerLives(player.playerHP);
                    enemyMissiles[i].DrawMissile();
                    enemyMissiles[i].ClearMissile();
                    enemyMissiles.RemoveAt(i);
                }
            }

            for (int i = 0; i < enemies.Count; i++)
            {
                int mLeft = enemies[i].posLeft;
                int mTop = enemies[i].posTop;
                int height = player.playerShip.Length;
                int width = player.playerShip[0].Length;

                if ((mLeft + width >= player.posLeft + 5 - 1 && mLeft - width + 1 <= player.posLeft)
                    && (mTop + height >= player.posTop && mTop - height <= player.posTop - 1))
                {
                    player.TakeHit();
                    gameInfo.DrawPlayerLives(player.playerHP);
                    enemies[i].enemyHp = 0;

                    enemies[i].DrawEnemy();
                    enemies[i].ClearEnemy();
                    enemies.RemoveAt(i);

                    gameInfo.IncreaseScore();
                    gameInfo.IncreaseDestroyedEnemies();
                }
            }
        }

        public void NameChoiceMenu()
        {
            player.ResetPlayer();
            gameInfo.ResetGameInfo();
            gameWindow.ClearScreen();
            gameWindow.DrawNameChoiceMenu();

            Console.CursorVisible = true;
            string name = Console.ReadLine();
            while (name.Length == 0)
            {
                Console.SetCursorPosition((Globals.WINDOW_WIDTH + 2 - gameWindow.nameChoice[0].Length) / 2, (Globals.WINDOW_HEIGHT - gameWindow.nameChoice.Length) / 2 + 6);
                name = Console.ReadLine();
            }

            player.playerName = name;
            gameInfo.playerName = name;
            Console.CursorVisible = false;
        }

        public void Tutorial()
        {
            gameWindow.ClearScreen();
            gameWindow.DrawTutorial();
            Console.ReadKey();
        }

        public Boolean Pause()
        {
            gameWindow.DrawPause();
            GameInput input = GameInput.enter;

            while (input != GameInput.exit && input != GameInput.space)
                input = inputHandler.GetInput();

            switch (input)
            {
                case GameInput.exit:
                    return false;
                    break;
                case GameInput.space:
                    return true;
                    break;
                default:
                    break;
            }
            return true;
        }

        public void GameOver()
        {
            gameWindow.DrawGameOver(gameInfo.score);
            GameInput input = GameInput.enter;

            if(gameInfo.score > 0)
                leaderboard.AddToLeaderboard(player.playerName, gameInfo.score);

            while (input != GameInput.exit)
                input = inputHandler.GetInput();
        }

        public void ShowLeaderboard()
        {
            gameWindow.ClearScreen();
            leaderboard.DrawLeaderboard();
            Console.ReadKey();
        }
    }
}
