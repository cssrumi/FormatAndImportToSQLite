using System;

namespace VPNCSVImporter
{
    class ImportExport
    {
        //private string fileName;
        private string stringIN;

        //Constructors
        public  ImportExport (string fileName)
        {
            //this.fileName = fileName;
            ImportExportFile(fileName);
        }

        //Methods
        private void ImportExportFile (string fileName)
        {
            Console.WriteLine("Rozpoczynam import!");
            Export export = new Export();
            SQLiteDB db = new SQLiteDB();
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            while((stringIN = file.ReadLine()) != null)
            {
                Format format = new Format(stringIN);
                //format.Show();
                export.ToSQLite(format, db);
            }
            Console.WriteLine("Import zakończony!");
            db.DisconnectSQLieteDB();
        }


        private void Show(string stringIN)
        {
            Console.WriteLine(stringIN);
        }
        //SetGet
    }
}
