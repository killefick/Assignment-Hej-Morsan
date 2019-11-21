using System;

namespace ClassLibHejMorsan
{
    class Program
    {
        static void Main(string[] args)
        {
            // instatntiate classes
            Person currentPerson = new Person();
            CountDown newCountdown = new CountDown();

            // initial day
            int day = 0;

            // get person list from database
            currentPerson.GetPersons();

            // loop though days
            while (true)
            {
                Console.Clear();
                day++;
                Console.WriteLine("Det är dag " + day + ":");
                Console.WriteLine("-------");

                foreach (var person in DB.myPersons)
                {
                    Console.WriteLine(person.Name + " " + person.CountDownTick);

                    // is it time to call the current person?
                    if (newCountdown.TimeToCallMom(person) == true)
                    {
                        Console.WriteLine("Vill du ringa " + person.Name + "? \nJa[1] eller nej[2]: ");

                        string input = Console.ReadLine();
                        if (input == "1")
                        {
                            newCountdown.MomHasBeenCalled(person);
                        }
                        else
                        {
                            newCountdown.Overdue(person);
                        }
                    }
                    else
                    {
                        // do not call
                    }

                    // update counter in database for current person
                    currentPerson.UpdateCounter(person.Id, person.CountDownTick);

                }
                Console.ReadKey();
            }
        }
    }
}