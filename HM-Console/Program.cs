using System;
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
                day++;
                Console.WriteLine($"Det är dag: {day}");
                Console.WriteLine("-------");
                newConsole.DailyLoop(P);
                loop = newConsole.StartMenu(P);
            }
        }
    }
}