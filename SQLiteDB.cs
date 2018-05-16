using System;
using System.Data.SQLite;

namespace SQLiteImporter
{
    class SQLiteDB
    {
        private string instanceName;
        SQLiteConnection dbConnection;
        SQLiteCommand dbCommand;
        //Constructors
        public SQLiteDB(string instanceName = "DB.sqlite")
        {
            SetInstanceName(instanceName);
            CheckSQLiteDB();
            ConnectSQLiteDB();
        }

        //Methods

        private void ConnectSQLiteDB()
        {
            dbConnection = new SQLiteConnection(
                "Data Source=" +
                instanceName +
                ";Version=3;");
            dbConnection.Open();
            //Console.WriteLine("Connected!");
        }

        public void DisconnectSQLieteDB()
        {
            dbConnection.Close();
        }

        private void CheckSQLiteDB()
        {
            if (System.IO.File.Exists(instanceName) == false)
                CreateSQLiteDB(); 
        }

        private void CreateSQLiteDB()
        {
            SQLiteConnection.CreateFile(instanceName);
            Console.WriteLine("SQLite DB created!");
            ConnectSQLiteDB();
            CreateRaportTable();
            //CreateUsersTable();
            DisconnectSQLieteDB();
        }

        private void CreateRaportTable()
        {
            string sql = "create table Report ("+
                "ID INTEGER PRIMARY KEY AUTOINCREMENT,"+
                "userName varchar(20), " +
                "startDate varchar(10), "+
                "startHour varchar(2), "+
                "deltaDateTime INTEGER, " +
                "startDateTime varchar(20), "+
                "finishDateTime varchar(20))";
            dbCommand = new SQLiteCommand(sql, dbConnection);
            dbCommand.ExecuteNonQuery();
        }

        public void Insert(Format format)
        {
            //ConnectSQLiteDB();
            string sql = "insert into Report ("+
                "userName, "+
                "startDate, "+
                "startHour, "+
                "deltaDateTime, "+
                "startDateTime, "+
                "finishDateTime"+
                ") values ('"+
                format.GetUserName()        + "', '" +
                format.GetStringStartDate() + "', '" +
                format.GetStartHour()       + "', '" +
                format.GetDeltaDateTime()   + "', '" +
                format.GetStartDateTime()   + "', '" +
                format.GetFinishDateTime()  + "')";
            dbCommand = new SQLiteCommand(sql, dbConnection);
            dbCommand.ExecuteNonQuery();
            //DisconnectSQLieteDB();
        }

        /*public void Command(string sql)
        {
            dbCommand = new SQLiteCommand(sql, dbConnection);
            dbCommand.ExecuteNonQuery();
        }*/

        public void Reader(string sql)
        {
            ConnectSQLiteDB();
            dbCommand = new SQLiteCommand(sql, dbConnection);
            SQLiteDataReader reader = dbCommand.ExecuteReader();
            while (reader.Read())
                Console.WriteLine(
                    "ID: " + reader["ID"] + "\t" +
                    "userName: " + reader["userName"] + 
                    "\tstartDate: " + reader["startDate"] +
                    "\tstartHour: " + reader["startHour"] +
                    "\tdeltaDateTime: " + reader["deltaDateTime"]);
            DisconnectSQLieteDB();
        }

        //SetGet
        private void SetInstanceName(string instanceName)
        {
            this.instanceName = instanceName;
        }
    }
}
