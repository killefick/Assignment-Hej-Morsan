using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using ClassLibHejMorsan;

namespace ClassLibHejMorsan
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "prutt";
            CountDown newCountdown = new CountDown();
            int day = 0;
            Person.GetPersons();

            while (true)
            {
                Console.Clear();
                day++; //öka dagarna
                //Skrivs ut i Main
                Console.WriteLine("Det är dag " + day + ":");
                Console.WriteLine("-------");

                foreach (var person in DB.myPersons)
                {

                    Console.WriteLine(person.Name + " " + person.CountDownTick);
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
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
