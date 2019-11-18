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
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public int Counter { get; set; }

        public static void DeletePerson(int idToDelete)
        {
            using (SqlConnection connection = new SqlConnection("Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;"))
            {
                int id = idToDelete;
                connection.Query<Person>("EXEC DeletePerson" + id);
            }
        }
    }
}