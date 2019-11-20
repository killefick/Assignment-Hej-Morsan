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
            CountDown newCountdown = new CountDown();
            int day = 0;

            while (true)
            {
                day++; //öka dagarna

                //Skrivs ut i Main
                Console.WriteLine("Det är dag " + day + ":");
                Console.WriteLine("-------");
                Person.GetPersons();

                if (newCountdown.LoopThroughList())
                {
                    Console.WriteLine("hej");
                }

                // if (newCountdown.TimeToCallMom())
                // {

                //     int choice;
                //     //Skall flyttas till main för att skrivas ut genom variabeln.
                //     System.Console.WriteLine($"Time to call {newCountdown.currentPerson.name}");
                //     System.Console.WriteLine("Press 1 to call.");
                //     try
                //     {
                //         choice = int.Parse(Console.ReadLine());
                //     }
                //     catch
                //     {
                //         System.Console.WriteLine($"You chose to not call {newCountdown.currentPerson.name}\n");
                //         choice = 0;
                //     }
                //     newCountdown.ChooseToCallMom(choice);
                // }
            }
        }
    }
}
