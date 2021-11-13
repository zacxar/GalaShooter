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
        private int rowCount;
        private int enemiesCount;
        private int[,] enemiesTable;
        private int[,] enemiesHp;
        private List<EnemyMissiles> enemyMissiles;
        private string[,] enemyTypes;

        public Enemy(string filePath)
        {
            TextReader textReader = File.OpenText(filePath);
            this.rowCount = int.Parse(textReader.ReadLine());
            this.enemiesCount = int.Parse(textReader.ReadLine());
            this.enemiesTable = new int[rowCount, enemiesCount];
            this.enemiesHp = new int[rowCount, enemiesCount];

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < enemiesCount; j++)
                {
                    int enemyType = textReader.Read();
                    enemiesTable[i, j] = enemyType;

                    switch (enemyType)
                    {
                        case 1:
                            enemiesHp[i, j] = 3;
                            break;
                        case 2:
                            enemiesHp[i, j] = 2;
                            break;
                        case 3:
                            enemiesHp[i, j] = 5;
                            break;
                    }
                }
            }

            this.enemyTypes = new string[,] {
                { "  ________  ",
                  " / ¨¨¨¨¨¨ \\ ",
                  "|  _ ≡≡ _  |",
                  "|─/ \\││/ \\─|",
                  "|/   ├┤   \\|" },

                { "  ________  ",
                  " / ¨¨¨¨¨¨ \\ ",
                  "|  _ ≡≡ _  |",
                  "|┌/ \\__/ \\┐|",
                  "|┤        ├|" },

                { " __________ ",
                  "/  ¨¨¨¨¨¨  \\",
                  "|   ≡  ≡   |",
                  " \\ /╔══╗\\ / ",
                  "  \\┤    ├/  " }
            };
        }
    }
}
