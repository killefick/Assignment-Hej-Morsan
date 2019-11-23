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
        public int initialCounter { get; set; }
        public int CountDownTick { get; set; }

        string connectionString = "Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;";

        // method to get person list
        public void GetPersons()
        {
            // creates connection object to connect to database
            var db = new DB(connectionString);

            // start with a fresh list
            DB.myPersons.Clear();
            
            // adds persons from database to list
            foreach (var person in db.GetPersonsFromDB())
            {
                DB.myPersons.Add(person);
                // sets counter variable that will decrease for each day 
                person.CountDownTick = person.Counter;
            }
        }

        // method to delete person from list
        public int DeletePerson(int id)
        {
            var db = new DB(connectionString);

            // deletes person from database
            db.DeletePersonFromDB(id);
            return id;
        }


        // method to update counter of a person
        public void UpdateCounter(int id, int counter)
        {
            var db = new DB(connectionString);

            // updates person on db
            db.UpdateCounterOnDB(id, counter);
        }


        // method to update a person
        public void UpdatePerson(int id, string name, string phone, string birthday, int counter)
        {
            var db = new DB(connectionString);

            // updates person on db
            db.UpdatePersonOnDB(id, name, phone,birthday, counter);
        }

        // method to add a person
        public void AddPerson(string name, string phone, string birthday, int counter)
        {
            var db = new DB(connectionString);

            // updates person on db
            db.AddPersonOnDB(name, phone, birthday, counter, counter);
        }
    }
}