namespace ClassLibHejMorsan
{
    // Everything handling The Countdowns
    class CountDown
    {
        int InitialDays = 3;
        int CountDownTick = 3;
        int CountDownOverdue = 0;

        // Decreases the countdown
        public void decrease()
        {
            CountDownTick--;
        }
        // Is it time to call mom?
        public bool TimeToCallMom()
        {
            if (CountDownTick == 0)
            {
                System.Console.WriteLine("Time To call mom");
                return true;
            }
            else if (CountDownTick < 0)
            {
                return true;
            }
            return false;
        }
        // If you don't call mom this starts to tick
        public int Overdue()
        {
            if (CountDownTick <= -1)
            {
                CountDownOverdue++;
            }
            return CountDownOverdue;
        }
        // Mom has been called and the counter resets to her initialdays
        public int MomHasBeenCalled()
        {
            CountDownTick = InitialDays;
            return CountDownTick;
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
    }
}