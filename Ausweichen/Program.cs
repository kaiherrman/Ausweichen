using System;
using Timer = System.Timers.Timer;


namespace Ausweichen
{
    class Program
    {
        public char[,] grid { get; set; }
        public static int playerPosX { get; set; }
        public static int playerPosY { get; set; }
        public static int oldPlayerPosX { get; set; }
        public static int oldPlayerPosY { get; set; }
        public static int amount { get; set; }

        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Program program = new Program();
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
            InitTimer();
            ConsoleConf confConsole = new ConsoleConf();
            Program program = new Program();
            confConsole.Reset();
            program.grid = new char[29, 100]; 

            while (true)
            {
                Console.Clear();
                program.grid[oldPlayerPosX, oldPlayerPosY] = ' ';
                program.grid[playerPosX, playerPosY] = '>';
                GenerateRandomRange(amount);
                for (int x = 0; x < program.grid.GetLength(0); x++)
                {
                    for (int y = 0; y < program.grid.GetLength(1); y++)
                    {
                        if (program.grid[x, y] == '>')
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
        public void GenerateRandomRange(int amount)
        {
            int[] randNumbers = new int[amount];
            for(int i = 0; i < amount; i++)
            {
                randNumbers[i] = rand.Next(0, 29);
            }
        }

        public void InitTimer()
        {
            Timer t = new Timer(15000);
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
            t.Start();
        }

        private static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (amount < 28)
                amount += 1;
        }

    }
}
