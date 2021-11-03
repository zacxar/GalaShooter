using System;

namespace GalaShooter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowSize(240, 63);
            //Console.SetBufferSize(240, 63);
            //Console.Write(Console.LargestWindowHeight);

            Game game = new Game();
            game.DrawTitle(7, 0);
            game.DrawBorders(0, 3);
            Console.ReadKey();
        }
    }
}
