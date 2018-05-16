using System;

namespace SQLiteImporter
{
    class Export
    {
        //Constructors

        public Export()
        {
        }

        //Methods
        public void ToSQLite(Format format, SQLiteDB db)
        {
            db.Insert(format);
        }

        public static void ToFile(Format format, string fileName)
        {
            Console.WriteLine("Not ready yet!");
        }

        //SetGet
    }
}
