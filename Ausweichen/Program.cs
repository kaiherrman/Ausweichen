using System;
using Timer = System.Timers.Timer;


namespace Ausweichen
{
    class Program
    {
        public static char[,] grid { get; set; }
        public int playerPosX { get; set; }
        public int playerPosY { get; set; }
        public int oldPlayerPosX { get; set; }
        public int oldPlayerPosY { get; set; }
        public int amount = 1;

        static void Main(string[] args)
        {
            ConsoleConf console = new ConsoleConf();
            console.ConsoleSize();

            Program program = new Program();

            Menu menu = new Menu();
            menu.PrintMenu();

            //Switch um abzufragen welche Taste gedrückt wird
            var inputKey = Console.ReadKey().Key;
            switch (inputKey)
            {
                case ConsoleKey.Enter:
                    program.Play();
                    break;
                case ConsoleKey.H:
                    menu.Help();
                    break;
                default:
                    break;
            }
        }

        public void Play()
        {
            //x is left & right
            //y is up & down
            ConsoleConf confConsole = new ConsoleConf();
            Program program = new Program();
            confConsole.Reset();
            grid = new char[29, 100];
            InitTimer();
            SpawnTimer();
            while (true)
            {
                Console.Clear();
                grid[oldPlayerPosX, oldPlayerPosY] = ' ';
                grid[playerPosX, playerPosY] = '>';

                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    for (int y = 0; y < grid.GetLength(1); y++)
                    {
                        if (grid[x, y] == '>')
                        {
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.Write(grid[x, y]);
                            confConsole.Reset();
                        }
                        else
                        {
                            Console.Write(grid[x, y]);
                        }
                    }
                    Console.Write(System.Environment.NewLine);
                }

                var inputKey = Console.ReadKey().Key;
                switch (inputKey)
                {
                    case ConsoleKey.UpArrow:
                        oldPlayerPosX = playerPosX;
                        if (playerPosX != 0)
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

        Random rand = new Random();
        public int[] GenerateRandomRange(int amount)
        {
            int[] randNumbers = new int[amount];
            for(int i = 0; i < amount; i++)
            {
                randNumbers[i] = rand.Next(0, 29);
            }
            return randNumbers;
        }

        public void InitTimer()
        {
            Timer t = new Timer(20000);
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(increaseDifficulty);
            t.Start();
        }

        public void SpawnTimer()
        {
            Timer tspawn = new Timer(10000);
            tspawn.AutoReset = true;
            tspawn.Elapsed += new System.Timers.ElapsedEventHandler(SpawnEnemys);
            tspawn.Start();
        }

        public void MoveEnemysTimer()
        {
            Timer tspawn = new Timer(3000);
            tspawn.AutoReset = true;
            tspawn.Elapsed += new System.Timers.ElapsedEventHandler(SpawnEnemys);
            tspawn.Start();
        }


        private void increaseDifficulty(object sender, System.Timers.ElapsedEventArgs e) //Triggers every 15 seconds
        {
            if (amount < 28) //Erhöht die Anzahl der Gegner
                amount += 1;
        }

        public void SpawnEnemys(object sender, System.Timers.ElapsedEventArgs e)
        {
            Program program = new Program();
            foreach (int Spawnpoint in GenerateRandomRange(amount))
            {
                grid[Spawnpoint, 99] = '5';
            }

            Random rng = new Random();
            grid[rng.Next(0, 29), 99] = ' ';
        }
        public void MoveEnemys(object sender, System.Timers.ElapsedEventArgs e)
        {
            for (int i = 0; i < 29; i++)
            {
                grid[i, 99 - 1] = grid[i, 99];
                grid[i, 99] = ' ';
            }
        }
    }
}
