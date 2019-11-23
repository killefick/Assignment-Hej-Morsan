using System;

using ClassLibHejMorsan;

namespace ClassLibHejMorsan
{
    class ConsoleMenu
    {
        Person currentPerson = new Person();
        CountDown newCountdown = new CountDown();

        public void StartMenu()
        {
            int UserInput = 0;
            System.Console.WriteLine("\n\n");
            System.Console.WriteLine("[1] Add a new Person");
            System.Console.WriteLine("[2] Update Person");
            System.Console.WriteLine("[3] Delete Person\n");
            System.Console.WriteLine("[4] Quit");
            try
            {
                UserInput = int.Parse(Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine("Wrong input");
            }
            switch (UserInput)
            {
                case 1:
                    {
                        AddandUpdatePerson();

                    }
                    break;
                case 2:
                    {
                        AddandUpdatePerson();
                    }
                    break;
                case 3:
                    {
                        DeletePerson();
                    }
                    break;
                case 4:
                    {

                    }
                    break;
            }

        }

        //The daily loop fetches the saved database, runs through it, person by person.
        //Gives the user the option to call if the counter has reached zero.
        //Otherwise triggers an overduecounter to display how many days overdue the user is.
        public void DailyLoop()
        {
            // currentPerson.GetPersons();
            foreach (var person in DB.myPersons)
            {

                Console.WriteLine(person.Name + " " + person.CountDownTick);
                if (newCountdown.TimeToCallMom(person) == true)
                {
                    Console.WriteLine($"Vill du ringa {person.Name}? \nJa[1] eller nej[2]: ");
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
                    //If mom hasn't been called
                }
            }
            currentPerson.UpdateCounter(currentPerson.Id, currentPerson.CountDownTick);
            Console.ReadKey();
        }

        private void DeletePerson()
        {
            int IdToDelete = 0;
            for (int i = 0; i < DB.myPersons.Count; i++)
            {
                System.Console.WriteLine($"{DB.myPersons[i + 1]}. {DB.myPersons[i].Name}");
            }
            System.Console.WriteLine("Which Person would you like to delete?");
            try
            {
                IdToDelete = int.Parse(Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine("Wrong input, try again");
            }
            System.Console.WriteLine($"Are you sure you want to delete id: {IdToDelete}");
            System.Console.WriteLine($"[Y]es/[N]o");
            string UserConfirmation = Console.ReadLine();

            switch (UserConfirmation)
            {
                case "Y":
                    {

                    }
                    break;
                case "N":
                    {

                    }
                    break;
                default:
                    {
                        System.Console.WriteLine("Wrong input.");
                    }
                    break;
            }
        }

        private void AddandUpdatePerson()
        {
            string name;
            string phone;
            string birthday;
            int counter;
            System.Console.WriteLine("Enter Name:");
            name = Console.ReadLine();
            System.Console.WriteLine("Enter TelePhone number:");
            phone = Console.ReadLine();
            System.Console.WriteLine("Enter Birthday:");
            birthday = Console.ReadLine();
            System.Console.WriteLine("Enter The Time interval:");
            counter = int.Parse(Console.ReadLine());

            currentPerson.AddPerson(name, phone.ToString(), birthday, counter);

        }
        private void UpdatePerson()
        {
            string name;
            string phone;
            string birthday;
            int counter;
            System.Console.WriteLine("Enter Name:");
            name = Console.ReadLine();
            System.Console.WriteLine("Enter TelePhone number:");
            phone = Console.ReadLine();
            System.Console.WriteLine("Enter Birthday:");
            birthday = Console.ReadLine();
            System.Console.WriteLine("Enter The Time interval:");
            counter = int.Parse(Console.ReadLine());

        }
    }
}