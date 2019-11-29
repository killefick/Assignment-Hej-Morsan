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
        public DB()
        {
            this.connectionString = "Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;";
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
                    connection.Query<Person>($"EXEC UpdateCounter {id}, '{counter}'");
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                throw;
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
                    connection.Query<Person>($"EXEC UpdatePerson {id}, {name}, '{phone}', '{birthday}', {counter}, {counter}");
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        internal void AddPersonOnDB(string name, string phone, string birthday, int counter)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Query<Person>($"EXEC AddPerson {name}, '{phone}', '{birthday}', {counter}, {counter} ");
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }

           public static bool FindUserInDB(int id, Person P)
        {

            foreach (var person in P.myPersons)
            {
                if (person.Id == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}