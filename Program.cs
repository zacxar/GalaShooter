using System;

namespace GalaShooter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(240, 63);
            Console.SetWindowSize(240, 63);
            Console.CursorVisible = false;

            Game game = new Game();
            game.GameLoop();

            Console.ReadKey();
        }
    }
}
