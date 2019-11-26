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

        // Mom has been called and the counter resets to her initialdays
        public void MomHasBeenCalled(Person Person)
        {
            Person.CountDownTick = Person.initialCounter;
            // return Person.CountDownTick;
        }
    }
}