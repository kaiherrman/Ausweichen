using System;

namespace Ausweichen
{
    class Program
    {
        public char[,] grid { get; set; }


        static void Main(string[] args)
        {
            //x is left & right
            //y is up & down

            ConsoleConf confConsole = new ConsoleConf();
            Program program = new Program();

            confConsole.ConsoleSize();
            confConsole.Reset();
            Console.Clear();

            program.grid = new char[61,60]; //First width then length


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine("   ");
            confConsole.Reset();

            Console.ReadLine();
        }
    }
}
