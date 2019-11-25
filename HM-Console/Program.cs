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
            bool loop = true;
            //Person.GetPersons(); <-- Den hämtar inte längre listan
            while (loop)
            {
                //Increases days
                // NOTE: SHould we have an Datetime here? should we add a timer?
                day++;
                Console.WriteLine("Det är dag " + day + ":");
                Console.WriteLine("-------");

                //Runs The program
                newConsole.DailyLoop();
                loop= false;
                newConsole.StartMenu();
                if (newConsole.StartMenu() == true)
                {
                loop=true;
                }
            }
        }
    }
}
