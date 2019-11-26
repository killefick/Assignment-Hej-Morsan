using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace ClassLibHejMorsan
{
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
        public IEnumerable<Person> GetPersonsFromDB()
        {
            try
            {
                // connects to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // connection.Query<xxx> allows multiple rows 
                    // connection.QueryFirst<xxx> allows only one row
                    return connection.Query<Person>("EXEC GetPersons");
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // method to update counter of a person on database
        public void UpdateCounterOnDB(int id, int counter)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<Person>($"EXEC UpdateCounter {id}, {counter}");
                }

            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Fel med DB!");
                // throw;
            }
        }

        // method to update counter of a person on database
        public void DeletePersonFromDB(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<Person>($"EXEC DeletePerson {id}");
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // method to update counter of a person on database
        public void UpdatePersonOnDB(int id, string name, string phone, string birthday, int counter)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<Person>($"EXEC UpdatePerson {id} {name} {phone} {birthday} {counter}");
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        internal void AddPersonOnDB(string name, string phone, string birthday, int counter, int initialCounter)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    initialCounter = counter;
                    connection.Query<Person>($"EXEC AddPerson {name}, {phone}, {birthday}, {counter}, {initialCounter} ");
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
    // EXEC AddPerson 'Pelle', '073-123456', '2019-08-09', 5, 5
    // EXEC AddPerson {name}, {phone}, {birthday}, {counter}, {initialCounter} 
}