using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassLibHejMorsan
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creating some object to be added to the list, this list is to offer some indata when showing the program.
            // To be deleted
            Person Mamma = new Person();
            Mamma.name = "Mamma";
            Mamma.initialDays = 7;
            Mamma.CountDownTick = Mamma.initialDays;

            Person Pappa = new Person();
            Pappa.name = "Pappa";
            Pappa.initialDays = 12;
            Pappa.CountDownTick = Pappa.initialDays;

            Person Syster = new Person();
            Syster.name = "Syster";
            Syster.initialDays = 10;
            Syster.CountDownTick = Syster.initialDays;

            Person Mormor = new Person();
            Mormor.name = "Mormor";
            Mormor.initialDays = 4;
            Mormor.CountDownTick = Mormor.initialDays;


            //List of persons that is supposed to connect to the database
            List<Person> PplToCall = new List<Person>();
            // PplToCall.Add(Mamma);
            // PplToCall.Add(Pappa);
            // PplToCall.Add(Syster);
            // PplToCall.Add(Mormor);
            // creates connection object to connect to database
            var db = new DB("Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;");

            // adds persons from databas to list
            foreach (var item in db.GetPersons())
            {
                PplToCall.Add(item);
            }

            int day = 0;
            while (true)
            {
                //Console.Clear();
                day++; //öka dagarna


                Console.WriteLine("Det är dag " + day + ":");
                Console.WriteLine("-------");


                foreach (Person person in PplToCall.ToList())
                {


                    if (person.CountDownTick > 0)
                    {
                        System.Console.WriteLine($"{person.name}: {person.CountDownTick} days left");
                    }
                    else if (person.CountDownTick <= -1)
                    {
                        System.Console.WriteLine($"{person.name}: {person.CountDownOverdue} days overdue.");
                    }

                    person.decrease();
                    person.TimeToCallMom();
                    if (person.TimeToCallMom() == true)
                    {
                        int choice;
                        System.Console.WriteLine($"Time to call {person.name}");
                        System.Console.WriteLine("Press 1 to call.");
                        try
                        {
                            choice = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            System.Console.WriteLine($"You chose to not call {person.name}");
                            choice = 0;
                        }
                        person.ChooseToCallMom(choice);

                    }

                }

                Console.ReadKey();

            }
        }
    }
}
