using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ausweichen
{
    class Menu
    {
        public void PrintMenu()
        {
            //Loop um Abstand von oben zu bekommen.
            for (int i = 0; i < 10; i++)
            {
                Console.Write(System.Environment.NewLine);
            }

            //string bestehend aus tabs um abstand von links zu bekommen.
            string centerTabs = "\t\t\t\t\t";

            Console.Write(centerTabs);
            Console.WriteLine("Highscore: {0}", Highscore()); //TODO: Get highscore from file? 
            Console.Write(centerTabs);
            Console.WriteLine("Drücken sie \"Eingabe\" zum starten!");
            Console.Write(Environment.NewLine);
            Console.Write(centerTabs);
            Console.WriteLine("Drücken sie \"H\" für Hilfe");
        }

        public void Help()
        {
            
        }

        public int Highscore()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Ausweichen\\Highscore.txt";
            if (File.Exists(path)) //Existiert die Datei?
            {
                if(File.ReadAllText(@path).Length != 0) //Befindet sich etwas in der Datei?
                {
                    return Convert.ToInt32(File.ReadAllText(@path));
                }
            }
            return 0;
        }
    }
}
