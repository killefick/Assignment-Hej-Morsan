using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace ClassLibHejMorsan
{
    public class DB
    {
        // List is supposed to be static because the list is global.
        public static List<Person> myPersons = new List<Person>();

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
        public IEnumerable<Person> AddPerson(string name, int counter)
        {
            // connects to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // connection.Query<xxx> allows multiple rows 
                // connection.QueryFirst<xxx> allows only one row
                return connection.Query<Person>($"EXEC AddPerson {name} {counter}");
            }

        }

    }
}