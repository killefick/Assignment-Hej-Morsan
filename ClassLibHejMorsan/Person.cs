using System.Collections.Generic;
namespace ClassLibHejMorsan
{
    // Create a PUBLIC class that maps to our SQL Table 
    // (or the QUERY – if the table contains more than that!)
    // Columns not mentioned in class will be ignored

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public int Counter { get; set; }
        public int CountDownTick { get; set; }
        public int initialCounter { get; set; }
        public int Overdue { get; set; }

        public override string ToString()
        {
            return "Namn:" + Name + "\tFödelsedag:" + Birthday + "\tMors-O-Meter:" + CountDownTick;
        }
        public List<Person> myPersons = new List<Person>();

        // method to get person list
        public void GetPersons()
        {
            // creates connection object to connect to database
            var db = new DB();
            // start with a fresh list
            myPersons.Clear();

            // adds persons from database to list
            try
            {
                foreach (var person in db.GetPersonsFromDB())
                {
                    myPersons.Add(person);
                    // sets counter variable that will decrease for each day 
                    person.CountDownTick = person.Counter;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // method to delete person from list
        public void DeletePerson(int id)
        {
            var db = new DB();
            // deletes person from database

            try
            {
                db.DeletePersonFromDB(id);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // method to update counter of a person
        public void UpdateCounter(int id, int counter)
        {
            var db = new DB();
            // updates person on db
            try
            {
                db.UpdateCounterOnDB(id, counter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // method to update a person
        public void UpdatePerson(int id, string name, string phone, string birthday, int counter)
        {
            var db = new DB();
            // updates person on db
            try
            {
                db.UpdatePersonOnDB(id, name, phone, birthday, counter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // method to add a person
        public void AddPerson(string name, string phone, string birthday, int counter)
        {
            var db = new DB();
            // updates person on db
            try
            {
                db.AddPersonOnDB(name, phone, birthday, counter);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}