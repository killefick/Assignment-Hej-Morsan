using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace ClassLibHejMorsan
{

// Everything handling The Countdowns
class CountDown
{

int InitialDays=3;
int CountDownTick=3;
int  CountDownOverdue=0;

        // Decreases the countdown
        public void decrease()
            {
                CountDownTick--;
            }
        // Is it time to call mom?
        public bool TimeToCallMom()
            {
            if(CountDownTick==0)
            {
                System.Console.WriteLine("Time To call mom");
                return true;
            }
            else if (CountDownTick <0)
            {
                return true;
            }
            return false;
            }
        // If you don't call mom this starts to tick
        public int Overdue()
        {
            if(CountDownTick<=-1)
            {
                CountDownOverdue++;
            }
            return CountDownOverdue;
        }
        // Mom has been called and the counter resets to her initialdays
        public int MomHasBeenCalled()
        {
            CountDownTick = InitialDays;
            return CountDownTick;
        }
        // Switch to handle choices, you either call mom or ignore her
        public void ChooseToCallMom(int choice)
        {
        switch(choice)
            {
                case 1:
                {
                    MomHasBeenCalled();
                }break;
                case 0:
                {
                    Overdue();
                }break;
            }
        }
}

    public class DB
    {
        // connectionString takes argument from "new DB"
        private readonly string connectionString;
        // constructor
        public DB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // public method to call from application
        // IEnumerable: allows looping over generic or non-generic lists
        public IEnumerable<Person> GetPersons()
        {
            // connects to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // connection.Query<xxx> allows multiple rows 
                // connection.QueryFirst<xxx> allows only one row
                return connection.Query<Person>("EXEC GetPersons");
            }
        }
    }
    // Create a PUBLIC class that maps to our SQL Table 
    // (or the QUERY – table contains more than that!)
    // Columns not mentioned in class will be ignored
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Counter { get; set; }
    }
}
