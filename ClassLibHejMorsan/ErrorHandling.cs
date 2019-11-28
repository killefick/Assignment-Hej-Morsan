namespace ClassLibHejMorsan
{
    public class ErrorHandling
    {

        public bool isInt(string intToProcess)
        {
            try
            {
                int.Parse(intToProcess);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool FindUserInDB(int id, Person P)
        {

            foreach (var person in P.myPersons)
            {
                if (person.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

    }
}