using System;

namespace Ausweichen
{
    class Program
    {
        public char[,] grid { get; set; }
        public static int playerPosX { get; set; }
        public static int playerPosY { get; set; }
        public static int oldPlayerPosX { get; set; }
        public static int oldPlayerPosY { get; set; }

        static void Main(string[] args)
        {
            //x is left & right
            //y is up & down

            ConsoleConf confConsole = new ConsoleConf();
            Program program = new Program();
            confConsole.Reset();
            //confConsole.ConsoleSize();
            confConsole.Reset();

            program.grid = new char[29,100]; //First width then height

            while (true)
            {
                Console.Clear();
                program.grid[oldPlayerPosX, oldPlayerPosY] = ' ';
                program.grid[playerPosX, playerPosY] = '>';

                for (int x = 0; x < program.grid.GetLength(0); x++)
                {
                    for (int y = 0; y < program.grid.GetLength(1); y++)
                    {
                        if(program.grid[x, y] == '>')
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write(program.grid[x, y]);
                            confConsole.Reset();
                        }
                        else
                        {
                            Console.Write(program.grid[x, y]);
                        }
                    }
                    Console.Write(System.Environment.NewLine);
                }

                var inputKey = Console.ReadKey().Key;
                switch (inputKey)
                {
                    case ConsoleKey.UpArrow:
                        oldPlayerPosX = playerPosX;
                        if(playerPosX != 0)
                        {
                            playerPosX -= 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        oldPlayerPosX = playerPosX;
                        if (playerPosX < 28)
                        {
                            playerPosX += 1;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

    }
}
