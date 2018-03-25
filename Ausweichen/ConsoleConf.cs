using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ausweichen
{
    class ConsoleConf
    {
        const int MF_BYCOMMAND = 0x00000000;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public void ConsoleSize()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(120, 25);
            Console.SetBufferSize(120, 25);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);
        }

        public void Reset()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
