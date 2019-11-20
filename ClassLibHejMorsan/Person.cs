using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;

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

        public static void DeletePerson(int idToDelete)
        {
            var db = new DB("Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;");

            using (SqlConnection connection = new SqlConnection("Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;"))
            {
                int id = idToDelete;
                connection.Query<Person>("EXEC DeletePerson " + id);
            }
        }


        public static void GetPersons()
        {
            // creates connection object to connect to database
            var db = new DB("Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;");

            // adds persons from databas to list
            foreach (var item in db.GetPersons())
            {
                DB.myPersons.Add(item);
            }
        }
    }
}