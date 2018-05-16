using System;

namespace SQLiteImporter
{
    class Program
    {
        private static string fileName;
        private static string credits = "Autor - cssrumi@gmail.com";
        private static string sqlString; 

        static void Main(string[] args)
        {
            Menu();
        }
        
        public static void Menu()
        {
            ConsoleKey key;
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(
                    credits + "\n\n"
                    + "Importować dane do Bazy\t- \"I\"\n"
                    + "Użyj select'a na Bazie\t- \"S\"\n"
                    + "Wyjdź\t\t\t- \"E\""
                    );
                key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.E:
                        exit = true;
                        break;
                    case ConsoleKey.I:
                        StartImport();
                        break;
                    case ConsoleKey.S:
                        Select();
                        break;
                    default:
                        break;
                }

            }
        }

        public static void StartImport()
        {
            Console.Clear();
            SetFileName("CSV\\csv.csv");
            ImportExport import = new ImportExport(fileName);
            Console.WriteLine("Naciśnij dowolny klawisz aby wrócić do Menu...");
            Console.ReadKey();
        }

        public static void Select()
        {
            Console.Clear();
            SQLiteDB db = new SQLiteDB();
            SetSqlString();
            db.Reader(sqlString);
            Console.WriteLine("Naciśnij dowolny klawisz aby wrócić do Menu...");
            Console.ReadKey();
        }

        //SetGet
        private static void SetFileName(string fileName)
        {
            string stringIN = "";
            Console.WriteLine("Podaj nazwę pliku wraz ze ścieżką lub naciśnij enter aby użyć domyślnej lokalizacji : " + fileName);
            stringIN = Convert.ToString(Console.ReadLine());
            if (stringIN != "")
                Program.fileName = stringIN;
            else
                Program.fileName = fileName;
        }

        private static void SetSqlString(string sqlString = "select * from Report order by 'ID'")
        {
            string stringIN = "";
            Console.WriteLine("Wpisz zapytanie do bazy SQLite - zostaw puste i naciśnij enter aby wyświetlić całą zawartość bazy");
            stringIN = Convert.ToString(Console.ReadLine());
            if (stringIN != "")
                Program.sqlString = stringIN;
            else
                Program.sqlString = sqlString;
        }
    }
}
