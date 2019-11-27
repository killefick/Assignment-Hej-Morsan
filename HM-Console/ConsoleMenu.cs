using System;
using System.Text.RegularExpressions;
using ClassLibHejMorsan;

namespace ClassLibHejMorsan
{
    class ConsoleMenu
    {
        // Person P = new Person();
        CountDown newCountdown = new CountDown();

        //The Menu, it's type is a bool because we only want to switch to a new day when we explicitly says so.

        //NOTE: WHen you have used one of the menuoptions, it loops once more and if you have someone to call it gets
        //stuck in that loop for infinity!
        public bool StartMenu(Person P)
        {
            string userInput = "";

            while (true)
            {
                System.Console.WriteLine("");
                System.Console.WriteLine("[1] Add a new Person");
                System.Console.WriteLine("[2] Update Person");
                System.Console.WriteLine("[3] Delete Person");
                System.Console.WriteLine("[4] Quit");
                System.Console.WriteLine("Make a choice or press any key to skip to next day...");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        {
                            AddPerson(P);
                            break;
                        }
                    case "2":
                        {
                            // UpdatePerson(P);
                            break;
                        }
                    case "3":
                        {
                            DeletePerson(P);
                            break;
                        }

                    case "4":
                        return false;

                    default:
                        return true;
                }
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
                    string input = "";
                    while (waitForCorrectInput)
                    {
                        Console.WriteLine($"Do you want to call {person.Name}? \n[Y]es or [N]o: ");
                        input = Console.ReadLine();
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
                                Console.WriteLine("Please write Y or N!");
                                Console.ReadLine();
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
            int idToDelete = 0;
            bool enteredInt = false;

            while (true)
            {
                idToDelete = 0;
                //Changed from a for loop to a foreach loop to make sure we don't fall out of scope
                //And to make it easier to get to the persons ID
                foreach (var person in P.myPersons)
                {
                    System.Console.WriteLine($"Id: {person.Id} {person.Name}");
                }

                while (!enteredInt)
                {
                    // ask for person's id to be deleted
                    System.Console.Write("Enter ID of person to delete: ");
                    // try to get a number
                    try
                    {
                        idToDelete = Convert.ToInt32(Console.ReadLine());
                        enteredInt = true;
                    }
                    catch
                    {
                        System.Console.WriteLine("Enter a number!");

                    }
                }


                // check if list of persons contains input ID
                string UserConfirmation = "";
                bool match = false;

                // Changed from for to foreach for the same reasons as for above, we never fall out of the list
                //and we don't have to go through an index to get to the persons ID
                foreach (var person in P.myPersons)
                {
                    if (person.Id == idToDelete)
                    {
                        match = true;
                        break;
                    }

                    else
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    System.Console.WriteLine($"Are you sure you want to delete ID: {idToDelete}");
                    System.Console.WriteLine($"[Y]es/[N]o");

                    string input = Console.ReadLine();
                    UserConfirmation = input.ToUpper();

                    // check user confirmation
                    while (true)
                    {
                        switch (UserConfirmation)
                        {
                            case "Y":
                                {
                                    System.Console.WriteLine("Person has been deleted. Press any key...");

                                    P.DeletePerson(idToDelete);
                                    Console.ReadLine();
                                    return;
                                }
                            case "N":
                                {
                                    System.Console.WriteLine("No one has been deleted. Press any key...");
                                    Console.ReadLine();
                                    return;
                                }
                            default:
                                {
                                    System.Console.WriteLine("Wrong input.");
                                    Console.ReadLine();
                                    break;
                                }
                        }
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Id does not exist! Press any key...");
                    enteredInt = false;
                    Console.ReadLine();
                }
            }
        }
        // Works as intended!
        private void AddPerson(Person P)
        {
            string name = "";
            string phone = "";
            string birthday = "";
            int counter = 0;

            bool checkInput = true;
            while (checkInput)
            {
                System.Console.Write("Enter Name: ");
                name = Console.ReadLine();
                if (name.Length <= 50)
                {
                    checkInput = false;
                }
                else
                {
                    Console.WriteLine("Enter max 50 characters!");
                }
            }

            checkInput = true;
            while (checkInput)
            {
                System.Console.Write("Enter Telephone number: ");
                phone = Console.ReadLine();
                if (phone.Length <= 20 && phone.Length > 10)
                {
                    checkInput = false;
                }
                else
                {
                    Console.WriteLine("Enter between 10 and 20 numbers!");
                }
            }

            // https://www.regular-expressions.info/dates.html
            // https://stackoverflow.com/questions/8764827/c-sharp-regex-validation-rule-using-regex-match
            var regex = @"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$";

            checkInput = true;
            while (checkInput)
            {
                System.Console.Write("Enter Birthday (YYYY-MM-DD): ");
                birthday = Console.ReadLine();

                var match = Regex.Match(birthday, regex, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    // does match
                    checkInput = false;
                }

                else
                {
                    Console.WriteLine("Enter format YYYY-MM-DD)!");
                }
            }

            // check for int
            checkInput = true;
            while (checkInput)
            {
                System.Console.Write("Enter the time interval (max 365): ");
                try
                {
                    counter = int.Parse(Console.ReadLine());
                    checkInput = false;
                }
                catch
                {
                    Console.WriteLine("Enter a number!");
                }
            }

            // // check for number
            checkInput = true;
            while (checkInput)
            {
                if (counter <= 365)
                {
                    checkInput = false;
                }
                else
                {
                    Console.WriteLine("Enter max 365 days!");
                    Console.ReadLine();
                }
            }

            // add person to DB
            P.AddPerson(name, phone.ToString(), birthday.ToString(), counter);
            
            System.Console.WriteLine($"{name} has been added to the list. Press any key...");
            Console.ReadLine();
        }

        //NOTE: Throws an error, not sure why.
        // TODO: Fix Error!

        //NOTE: Only works if we display the database ID atm (Same as Deleteperson)
        // TODO: Somehow fix so that it displays the index number, but uses the id in the database

        //     private void UpdatePerson(Person P)
        //     {
        //         int IdToUpdate = 0;
        //         for (int i = 0; i < P.myPersons.Count; i++)
        //         {

        //             System.Console.WriteLine($"{P.myPersons[i].Id}. {P.myPersons[i].Name}");
        //         }
        //         System.Console.WriteLine("Which Person would you like to Update?");
        //         try
        //         {
        //             IdToUpdate = int.Parse(Console.ReadLine());
        //         }
        //         catch
        //         {
        //             System.Console.WriteLine("Wrong input, try again");
        //         }
        //         string name;
        //         string phone;
        //         string birthday;
        //         int counter = 0;

        //         System.Console.Write("Enter Name: ");
        //         name = Console.ReadLine();
        //         System.Console.Write("Enter TelePhone number: ");
        //         phone = Console.ReadLine();
        //         System.Console.Write("Enter Birthday: ");
        //         birthday = Console.ReadLine();
        //         System.Console.Write("Enter The Time interval: ");
        //         try
        //         {
        //             counter = int.Parse(Console.ReadLine());
        //         }
        //         catch
        //         {
        //             System.Console.WriteLine("Wrong input, try again");
        //         }
        //         P.UpdatePerson(IdToUpdate, name, phone, birthday, counter);

        //     }
    }
}