namespace ClassLibHejMorsan
{
    // Everything handling The Countdowns
    public class CountDown
    {
        // Is it time to call mom?
        public bool TimeToCallMom(Person Person)
        {
            // one day less
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
    }
}