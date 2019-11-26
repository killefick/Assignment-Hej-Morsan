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
                System.Console.WriteLine("Make a choice or press any key to skip to next day...");

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
            foreach (var person in P.myPersons)
            {
                bool waitForCorrectInput = true;
                // print person's details
                Console.WriteLine($"{person.Name}: {person.CountDownTick}");

                if (newCountdown.TimeToCallMom(person) == true)
                {
                    while (waitForCorrectInput)
                    {
                        Console.WriteLine($"Do you want to call {person.Name}? \n[Y]es or [N]o: ");
                        string input = Console.ReadLine();
                        string userInput = input.ToUpper();

                        switch (userInput)
                        {
                            case "Y":
                                newCountdown.MomHasBeenCalled(person);
                                waitForCorrectInput = false;
                                break;

                            case "N":
                                Console.WriteLine($"You chose not to call {person.Name}.");
                                waitForCorrectInput = false;
                                continue;

                            default:
                                Console.WriteLine("Plrease write Y or N!");
                                Console.Read();
                                break;
                        }
                    }
                }
                person.UpdateCounter(person.Id, person.CountDownTick);
            }
        }

        // deletes a person from DB
        private void DeletePerson(Person P)
        {
            bool enteredInt = false;
            int idToDelete = 0;

            while (true)
            {
                // ask for person's id to be deleted
                for (int i = 0; i < P.myPersons.Count; i++)
                {
                    System.Console.WriteLine($"Id: {P.myPersons[i].Id} {P.myPersons[i].Name}");
                }
                while (!enteredInt)
                {
                    System.Console.Write("Enter ID of person to delete: ");
                    // try to get a number
                    try
                    {
                        idToDelete = int.Parse(Console.ReadLine());
                        enteredInt = true;
                    }
                    catch
                    {
                        System.Console.WriteLine("Enter a number!");

                    }
                }
                // check if list of persons contains input ID
                if (P.myPersons.Count.ToString().Contains(idToDelete.ToString()))
                {
                    System.Console.WriteLine($"Are you sure you want to delete ID: {idToDelete}");
                    System.Console.WriteLine($"[Y]es/[N]o");

                    string input = Console.ReadLine();
                    string UserConfirmation = input.ToUpper();

                    // check user confirmation
                    while (true)
                    {
                        switch (UserConfirmation)
                        {
                            case "Y":
                                {
                                    P.DeletePerson(idToDelete);
                                    System.Console.WriteLine($"{P.Name} has been deleted.");
                                    Console.Read();
                                }
                                break;
                            case "N":
                                {
                                    System.Console.WriteLine("No one has been deleted.");
                                    Console.Read();
                                }
                                break;
                            default:
                                {
                                    System.Console.WriteLine("Wrong input.");
                                    Console.Read();
                                }
                                break;
                        }
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Id does not exist! Press any key...");
                    Console.Read();
                }
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