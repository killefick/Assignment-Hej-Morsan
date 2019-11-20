// Possibly unnecessary? If we have all our functions in Person.cs


// // Everything handling The Countdowns
// class CountDown
// {

// int InitialDays=3;

namespace ClassLibHejMorsan
{
    // Everything handling The Countdowns
    public class CountDown
    {
       public Person currentPerson = new Person();

        int CountDownOverdue = 0;

        // Decreases the countdown
        public void decrease()
        {
            currentPerson.CountDownTick--;
        }
        // Is it time to call mom?
        public bool TimeToCall()
        {
            if (currentPerson.CountDownTick == 0)
            {
                return true;
            }
            else if (currentPerson.CountDownTick < 0)
            {
                return true;
            }
            return false;
        }
        // If you don't call mom this starts to tick
        public int Overdue()
        {
            if (currentPerson.CountDownTick <= -1)
            {
                CountDownOverdue++;
            }
            return CountDownOverdue;
        }
        // Mom has been called and the counter resets to her initialdays
        public int MomHasBeenCalled()
        {
            currentPerson.CountDownTick = currentPerson.initialDays;
            return currentPerson.CountDownTick;
        }
        // Switch to handle choices, you either call mom or ignore her
        public void ChooseToCallMom(int choice)
        {
            switch (choice)
            {
                case 1:
                    {
                        MomHasBeenCalled();
                    }
                    break;
                case 0:
                    {
                        Overdue();
                    }
                    break;
            }
        }

        public void RunCountDown()
        {
        bool TimeToCall = this.TimeToCall();

                foreach (Person person in Person.myPersons)
                {

                    //En variabel som ändras beroende på countdowntick. Skickas sedan vidare till en switch i main som skriver ut det som är kopplat till siffran.
                    int variable;

                    if (person.CountDownTick > 0)
                    {
                        
                        // Skall flyttas till main: System.Console.WriteLine($"{person.name}: {person.CountDownTick} days left");
                        variable = 1;
                    }
                    else if (person.CountDownTick <= -1)
                    {
                        //Skall flyttas till main: System.Console.WriteLine($"{person.name}: {person.CountDownOverdue} days overdue.");
                        variable=2;
                    }

                    decrease();
                }
            }
        }
                    

    }
