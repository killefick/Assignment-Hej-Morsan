using System;

using ClassLibHejMorsan;

namespace ClassLibHejMorsan
{
    class ConsoleMenu
    {
        // Person P = new Person();
        CountDown newCountdown = new CountDown();

        //The Menu, it's type is a bool because we only want to switch to a new day when we explicitly says so.
        public bool StartMenu(Person P)
        {
            string userInput = "";

            while (true)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("[1] Add a new Person");
                System.Console.WriteLine("[2] Update Person");
                System.Console.WriteLine("[3] Delete Person");
                System.Console.WriteLine("Press any key to skip to next day...");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            AddPerson(P);
                        }
                        break;
                    case "2":
                        {
                            UpdatePerson(P);
                        }
                        break;
                    case "3":
                        {
                            DeletePerson(P);
                        }
                        break;
                    default:
                        return true;
                }
                return false;
            }
        }

        //The daily loop fetches the saved database, runs through it, person by person.
        //Gives the user the option to call if the counter has reached zero.
        //Otherwise triggers an overduecounter to display how many days overdue the user is.
        public void DailyLoop(Person P)
        {
            // load persons from DB
            P.GetPersons();
            bool waitForCorrectInput = true;
            foreach (var person in P.myPersons)
            {
                // if it's not time to call yet
                // if (person.CountDownTick > -1)
                // {
                // print person's details
                Console.WriteLine($"{person.Name}: {person.CountDownTick}");
                // }
                // if it's time to call
                // else
                // {
                //     System.Console.WriteLine($"{person.Name}: {person.Overdue} overdue");
                // }

                if (newCountdown.TimeToCallMom(person) == true)
                {
                    while (waitForCorrectInput)
                    {
                        Console.WriteLine($"Vill du ringa {person.Name}? \n[Y]es or [N]o: ");
                        string input = Console.ReadLine();
                        string userInput = input.ToUpper();

                        switch (userInput)
                        {
                            case "Y":
                                newCountdown.MomHasBeenCalled(person);
                                waitForCorrectInput = false;
                                break;

                            case "N":
                                Console.WriteLine($"Du valde att inte ringa {person.Name}.");
                                waitForCorrectInput = false;
                                continue;

                            default:
                                Console.WriteLine("Vänligen skriv Y eller N!");
                                Console.Read();
                                break;
                        }
                    }
                }
                person.UpdateCounter(person.Id, person.CountDownTick);
            }
        }

        //NOTE: Only works if we display the database ID atm
        // TODO: Somehow fix so that it displays the index number, but uses the id in the database
        private void DeletePerson(Person P)
        {
            int IdToDelete = 0;
            for (int i = 0; i < P.myPersons.Count; i++)
            {
                System.Console.WriteLine($"{P.myPersons[i].Id}. {P.myPersons[i].Name}");
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
            string input = Console.ReadLine();
            string UserConfirmation = input.ToUpper();

            switch (UserConfirmation)
            {
                case "Y":
                    {
                        P.DeletePerson(IdToDelete);
                        System.Console.WriteLine($"{P.Name} has been deleted");
                        Console.Clear();
                    }
                    break;
                case "N":
                    {
                        System.Console.WriteLine("No one has been deleted");
                        Console.Clear();
                    }
                    break;
                default:
                    {
                        System.Console.WriteLine("Wrong input.");
                    }
                    break;
            }
        }
        //NOTE: Can't deal with spaces, throws an error.
        // TODO: Fix error?
        private void AddPerson(Person P)
        {
            string name;
            string phone;
            string birthday;
            int counter;

            System.Console.Write("Enter Name: ");
            name = Console.ReadLine();
            System.Console.Write("Enter Telephone number: ");
            phone = Console.ReadLine();
            System.Console.Write("Enter Birthday: ");
            birthday = Console.ReadLine();
            System.Console.Write("Enter The Time interval: ");
            counter = int.Parse(Console.ReadLine());

            P.AddPerson(name, phone.ToString(), birthday, counter);
            System.Console.WriteLine($"{name}, has been added to the list.");
            Console.Clear();

        }

        //NOTE: Throws an error, not sure why.
        // TODO: Fix Error!

        //NOTE: Only works if we display the database ID atm (Same as Deleteperson)
        // TODO: Somehow fix so that it displays the index number, but uses the id in the database

        private void UpdatePerson(Person P)
        {
            int IdToUpdate = 0;
            for (int i = 0; i < P.myPersons.Count; i++)
            {

                System.Console.WriteLine($"{P.myPersons[i].Id}. {P.myPersons[i].Name}");
            }
            System.Console.WriteLine("Which Person would you like to Update?");
            try
            {
                IdToUpdate = int.Parse(Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine("Wrong input, try again");
            }
            string name;
            string phone;
            string birthday;
            int counter = 0;

            System.Console.Write("Enter Name: ");
            name = Console.ReadLine();
            System.Console.Write("Enter TelePhone number: ");
            phone = Console.ReadLine();
            System.Console.Write("Enter Birthday: ");
            birthday = Console.ReadLine();
            System.Console.Write("Enter The Time interval: ");
            try
            {
                counter = int.Parse(Console.ReadLine());
            }
            catch
            {
                System.Console.WriteLine("Wrong input, try again");
            }
            P.UpdatePerson(IdToUpdate, name, phone, birthday, counter);

        }
    }
}