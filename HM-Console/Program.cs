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
            ConsoleMenu newConsole = new ConsoleMenu();

            int day = 0;
            //Person.GetPersons(); <-- Den hämtar inte längre listan
            while (true)
            {
                //Increases 
                day++;
                Console.WriteLine("Det är dag " + day + ":");
                Console.WriteLine("-------");
                //Runs The program
                newConsole.DailyLoop();
            }
        }
    }
}
