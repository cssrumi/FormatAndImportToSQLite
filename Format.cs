using System;

namespace SQLiteImporter
{
    class Format
    {
        private string userName;
        private DateTime startDateTime;
        private DateTime finishDateTime;
        private TimeSpan deltaDateTime;
        private string stringIN;
        //private DateTime startDate;
        private string stringStartDate;
        private string startHour;
        private char separator;

        //Constructors
        public Format (string stringIN , char separator=';')
        {
            SetStringIN(stringIN);
            SetSeparator(separator);
            FormatString();
            SetDeltaDateTime();
            SetStringStartDate();
        }

        //Methods
        private void FormatString()
        {
            string[] tab = new string[3];
            int counter = 0;
            string temp = "";
            for(int i = 0; i < stringIN.Length; i++)
            {
                if (stringIN[i] == separator)
                {
                    tab[counter] = temp;
                    counter++;
                    temp = "";
                }
                else
                    temp += stringIN[i];
            }
            tab[2] = temp;
            SetUserName(tab[0]);
            SetStartDateTime(tab[1]);
            SetFinishDateTime(tab[2]);
            SetStartHour();
        }

        public void Show()
        {
            Console.WriteLine(
                userName + " " + 
                //startDateTime + " " + 
                //finishDateTime + " " + 
                Convert.ToInt32(deltaDateTime.TotalMinutes)// + " " +
                //startHour + " " +
                //stringStartDate// + " " + 
                //GetStartDateTime() + " " + 
                //GetFinishDateTime()
                );
        }

        //SetGet
        private void SetStringStartDate()
        {
            stringStartDate = startDateTime.ToString("dd.MM.yyyy");
        }
        public string GetStringStartDate()
        {
            return stringStartDate;
        }
        private void SetStartHour()
        {
            string temp = Convert.ToString(startDateTime);
            startHour = "";
            startHour += temp[11]; 
            startHour += temp[12];
        }
        public string GetStartHour()
        {
            return startHour;
        }
        private void SetDeltaDateTime()
        {
            deltaDateTime = finishDateTime - startDateTime;
        }
        public int GetDeltaDateTime()
        {
            return Convert.ToInt32(deltaDateTime.TotalMinutes);
        }
        private void SetUserName(string stringIN)
        {
            userName = stringIN;
        }
        public string GetUserName()
        {
            return userName;
        }
        private void SetStartDateTime(string stringIN)
        {
            startDateTime = Convert.ToDateTime(stringIN);
        }
        public string GetStartDateTime()
        {
            return Convert.ToString(startDateTime);
        }
        private void SetFinishDateTime(string stringIN)
        {
            finishDateTime = Convert.ToDateTime(stringIN);
        }
        public string GetFinishDateTime()
        {
            return Convert.ToString(finishDateTime);
        }
        private void SetStringIN(string stringIN)
        {
            this.stringIN = stringIN;
        }
        private string GetStringIN()
        {
            return stringIN;
        }
        private void SetSeparator(char separator)
        {
            this.separator = separator;
        }
        private char GetSeparator()
        {
            return separator;
        }
    }   
}
