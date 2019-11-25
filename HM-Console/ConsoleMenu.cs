using System;

using ClassLibHejMorsan;

namespace ClassLibHejMorsan
{
    class ConsoleMenu
    {
        Person currentPerson = new Person();
        CountDown newCountdown = new CountDown();

        //The Menu, it's type is a bool because we only want to switch to a new day when we explicitly says so.
        public bool StartMenu()
        {
            int UserInput = 0;
            System.Console.WriteLine("\n\n");
            System.Console.WriteLine("[1] Add a new Person");
            System.Console.WriteLine("[2] Update Person");
            System.Console.WriteLine("[3] Delete Person\n");
            System.Console.WriteLine("[4] New Day");
            try
            {
                UserInput = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.ReadKey();
            }
            switch (UserInput)
            {
                case 1:
                    {
                        AddPerson();

                    }
                    break;
                case 2:
                    {
                        UpdatePerson();
                    }
                    break;
                case 3:
                    {
                        DeletePerson();
                    }
                    break;
                case 4:
                    {
                        //We want a new day, the value is true and triggers the loop in program.cs
                        return true;
                    }
            }
            return false;

        }

        //The daily loop fetches the saved database, runs through it, person by person.
        //Gives the user the option to call if the counter has reached zero.
        //Otherwise triggers an overduecounter to display how many days overdue the user is.
        public void DailyLoop()
        {
            currentPerson.GetPersons();
            foreach (var person in currentPerson.myPersons)
            {
                if(person.CountDownTick > -1)
                {
                    Console.WriteLine($"{person.Name}: {person.CountDownTick}");
                }
                // NOTE: Can't be used until we have fixed the OverdueCounter.
                // else
                // {
                //     System.Console.WriteLine($"{person.Name}: {person.Overdue} overdue");
                // }

                if (newCountdown.TimeToCallMom(person) == true)
                {
                    Console.WriteLine($"Vill du ringa {person.Name}? \n[Y]es or [N]o: ");
                    string input = Console.ReadLine();
                    string UserInput = input.ToUpper();
                    if (UserInput == "Y")
                    {
                        newCountdown.MomHasBeenCalled(person);
                    }
                    else
                    {
                        //NOTE: Doesn't work atm.
                        newCountdown.Overdue(person);
                    }
             }
                else
                {
                    //Mom doesn't need to be called
                }
            person.UpdateCounter(person.Id, person.CountDownTick);
            }
        }

        //NOTE: Only works if we display the database ID atm
        // TODO: Somehow fix so that it displays the index number, but uses the id in the database
        private void DeletePerson()
        {
            int IdToDelete = 0;
            for (int i = 0; i < currentPerson.myPersons.Count; i++)
            {
                System.Console.WriteLine($"{currentPerson.myPersons[i].Id}. {currentPerson.myPersons[i].Name}");
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
                        currentPerson.DeletePerson(IdToDelete);
                        System.Console.WriteLine($"{currentPerson.Name} has been deleted");
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
        private void AddPerson()
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

            currentPerson.AddPerson(name, phone.ToString(), birthday, counter);
            System.Console.WriteLine($"{name}, has been added to the list.");
            Console.Clear();

        }

        //NOTE: Throws an error, not sure why.
        // TODO: Fix Error!

        //NOTE: Only works if we display the database ID atm (Same as Deleteperson)
        // TODO: Somehow fix so that it displays the index number, but uses the id in the database

        private void UpdatePerson()
        {
            int IdToUpdate = 0;
            for (int i = 0; i < currentPerson.myPersons.Count; i++)
            {

                System.Console.WriteLine($"{currentPerson.myPersons[i].Id}. {currentPerson.myPersons[i].Name}");
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
            int counter=0;

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
            currentPerson.UpdatePerson(IdToUpdate,name,phone,birthday,counter);

        }
    }
}