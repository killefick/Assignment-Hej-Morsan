using System;
using System.Text.RegularExpressions;
using ClassLibHejMorsan;

namespace ClassLibHejMorsan
{
    class ConsoleMenu
    {
        CountDown newCountdown = new CountDown();

        //The Menu type is bool because we only want to switch to a new day when we explicitly says so.
        public bool StartMenu(Person P)
        {
            string userInput = "";

            while (true)
            {
                int Statementvalue = 0;
                int typeOfInserttoDB = 0;
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
                            //TODO: explain what this does
                            typeOfInserttoDB = 1;
                            AddorUpdatePerson(P, Statementvalue, typeOfInserttoDB);
                            // refreshes person list
                            P.GetPersons();
                            break;
                        }
                    case "2":
                        {
                            Statementvalue = 2;
                            typeOfInserttoDB = 2;
                            AddorUpdatePerson(P, Statementvalue, typeOfInserttoDB);
                            P.GetPersons();
                            break;
                        }
                    case "3":
                        {
                            DeletePerson(P);
                            P.GetPersons();
                            break;
                        }
                    // quit program
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
                Console.WriteLine($"Namn: {person.Name}\tFödelsedag: {person.Birthday}\tMors-O-Meter: {person.CountDownTick}");

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

        //Adds or Updates a person depending on the values set in the menu, to the database
        private void AddorUpdatePerson(Person P, int Statementvalue, int typeOfInserttoDB)
        {
            string name = "";
            string phone = "";
            string birthday = "";
            int counter = 0;
            int IdToUpdate = 0;
            bool matchinDB = true;
            bool enteredInt = false;
            bool checkInput = true;
            bool Majorloop = true;

            if (Statementvalue == 2)
            {

                while (Majorloop)
                {
                    enteredInt = false;

                    foreach (var person in P.myPersons)
                    {
                        System.Console.WriteLine($"Id: {person.Id} {person.Name}");
                    }

                    while (!enteredInt)
                    {
                        // ask for person's id to be deleted
                        System.Console.Write("Enter ID of person to update: ");
                        // try to get a number
                        try
                        {
                            IdToUpdate = Convert.ToInt32(Console.ReadLine());
                            enteredInt = true;
                        }
                        catch
                        {
                            System.Console.WriteLine("Enter a number!");

                        }
                    }
                    foreach (var person in P.myPersons)
                    {
                        if (person.Id == IdToUpdate)
                        {
                            matchinDB = true;
                            Majorloop = false;
                            break;
                        }

                        else
                        {
                            matchinDB = false;
                        }
                    }
                    if (!matchinDB)
                    {
                        Console.WriteLine("Id does not exist! Press any key...");
                        enteredInt = false;
                        Console.ReadLine();
                    }
                }
            }

            while (checkInput)
            {
                System.Console.Write("Enter Name: ");
                name = Console.ReadLine();
                if (name.Length <= 50 && name.Length > 2)
                {
                    checkInput = false;
                }
                else
                {
                    Console.WriteLine("Enter between 3 and 50 characters!");
                }
            }

            // https://stackoverflow.com/questions/8764827/c-sharp-regex-validation-rule-using-regex-match
            // https://stackoverflow.com/questions/20678300/sweden-phone-number-regular-expression
            var regex = @"^([+]46)\s*(7[0236])\s*(\d{4})\s*(\d{3})$";
            checkInput = true;
            while (checkInput)
            {
                System.Console.Write("Enter Telephone number: ");
                phone = Console.ReadLine();
                var match = Regex.Match(phone, regex, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    checkInput = false;
                }
                else
                {
                    Console.WriteLine("Enter between 10 and 20 numbers!");
                }
            }

            // https://www.regular-expressions.info/dates.html
            regex = @"^(19|20)\d\d[- /.](0[1-9]|1[012])[- /.](0[1-9]|[12][0-9]|3[01])$";

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
                    Console.WriteLine("Enter a valid date, format YYYY-MM-DD)!");
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
                    checkInput = true;
                }

                if (counter <= 365 && checkInput == false)
                {
                    checkInput = false;
                }
                else
                {
                    Console.WriteLine("Enter a number of max 365 days!");
                    checkInput = true;
                }
            }

            switch (typeOfInserttoDB)
            {
                case 1:
                    {
                        // add person to DB
                        P.AddPerson(name, phone.ToString(), birthday.ToString(), counter);

                        System.Console.WriteLine($"{name} has been added to the list. Press any key...");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    {
                        // update person
                        P.UpdatePerson(IdToUpdate, name, phone, birthday, counter);
                        System.Console.WriteLine($"{name} has been updated. Press any key...");
                    }
                    break;
            }
        }
    }
}