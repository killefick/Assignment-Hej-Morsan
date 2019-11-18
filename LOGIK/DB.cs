using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace Hej_Morsan_Projekt
{
    class DB
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