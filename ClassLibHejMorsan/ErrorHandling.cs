namespace ClassLibHejMorsan
{
    // errorhandling is supposed to be used globally, not onl om instances of a class
    public static class ErrorHandling
    {
        // keyword "this" makes method available in intellisense
        public static bool inputIsInt(this string intToProcess)
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
    }
}