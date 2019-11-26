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
            Person P = new Person();
            int day = 0;
            bool loop = true;

            while (loop)
            {
                Console.Clear();
                //Increases days
                day++;
                Console.WriteLine("Det är dag " + day + ":");
                Console.WriteLine("-------");

                //Runs The program
                newConsole.DailyLoop(P);
                loop = newConsole.StartMenu(P); //TODO: returnerar true men 
            }
        }
    }
}