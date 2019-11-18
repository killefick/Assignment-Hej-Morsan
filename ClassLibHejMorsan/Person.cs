using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace ClassLibHejMorsan
{
// Create a PUBLIC class that maps to our SQL Table 
    // (or the QUERY – table contains more than that!)
    // Columns not mentioned in class will be ignored
    public class Person
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public int initialDays { get; set; }
        public int CountDownTick { get; set; }
        public int CountDownOverdue = 0;

        public static void DeletePerson()
        {

            // creates connection object to connect to database
            using (SqlConnection connection = new SqlConnection("Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;"))
            {
                 connection.Query<Person>("EXEC DeletePerson 4");
                
            }
        }

                // Decreases the countdown
        public void decrease()
        {
            CountDownTick--;
        }
        // Is it time to call mom?
        public bool TimeToCallMom()
        {
            if (CountDownTick == 0-1)
            {
                return true;
            }
            else if (CountDownTick < 0-1)
            {
                return true;
            }
            return false;
        }
        // If you don't call mom this starts to tick
        public int Overdue()
        {
            if (CountDownTick <= -1)
            {
                CountDownOverdue++;
            }
            return CountDownOverdue;
        }
        // Mom has been called and the counter resets to her initialdays
        public int MomHasBeenCalled()
        {
            CountDownTick = initialDays;
            return CountDownTick;
        }
        // Switch to handle choices, you either call mom or ignore her
        public void ChooseToCallMom(int choice)
        {
            switch (choice)
            {
                case 1:
                    {
                        MomHasBeenCalled();
                    }
                    break;
                case 0:
                    {
                        Overdue();
                    }
                    break;
            }
        }
    }
}