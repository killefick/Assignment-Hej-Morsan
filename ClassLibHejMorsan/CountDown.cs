namespace ClassLibHejMorsan
{
    // Everything handling The Countdowns
    public class CountDown
    {

        // Is it time to call mom?
        public bool TimeToCallMom(Person Person)
        {
            Person.CountDownTick--;

            if (Person.CountDownTick <= -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // If you don't call mom this starts to tick
        public int Overdue(Person Person)
        {
            int CountDownOverdue = 0;

            if (Person.CountDownTick <= -1)
            {
                CountDownOverdue++;
            }
            return CountDownOverdue;
        }

        // Mom has been called and the counter resets to her initialdays
        public int MomHasBeenCalled(Person Person)
        {
            int number = 0;
            Person.CountDownTick = Person.Counter;
            number = Person.CountDownTick;

            return number;
        }

        // // Switch to handle choices, you either call mom or ignore her
        // public void ChooseToCallMom(int choice)
        // {
        //     switch (choice)
        //     {
        //         case 1:
        //             {
        //                 MomHasBeenCalled();
        //             }
        //             break;
        //         case 0:
        //             {
        //                 Overdue();
        //             }
        //             break;
        //     }
        // }

        // public void RunCountDown()
        // {
        //     bool TimeToCall = this.TimeToCallMom();

        //     foreach (Person person in DB.myPersons)
        //     {

        //         //En variabel som ändras beroende på countdowntick. Skickas sedan vidare till en switch i main som skriver ut det som är kopplat till siffran.
        //         int variable;

        //         if (person.CountDownTick > 0)
        //         {

        //             // Skall flyttas till main: System.Console.WriteLine($"{person.name}: {person.CountDownTick} days left");
        //             variable = 1;
        //         }
        //         else if (person.CountDownTick <= -1)
        //         {
        //             //Skall flyttas till main: System.Console.WriteLine($"{person.name}: {person.CountDownOverdue} days overdue.");
        //             variable = 2;
        //         }
        //         Decrease();
        //     }
        // }
    }


}
