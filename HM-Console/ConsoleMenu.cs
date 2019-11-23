using System;

using ClassLibHejMorsan;

namespace ClassLibHejMorsan
{
    class ConsoleMenu
    {
        Person currentPerson = new Person();

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