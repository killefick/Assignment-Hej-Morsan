using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;

namespace Hej_Morsan_Projekt.Pages
{
    public class IndexModel : PageModel
    {
        // instantiate class
        Person person = new Person();

        // create list to store persons from database 
        public List<Person> myPersons = new List<Person>();

        public void OnGet()
        {
            // create list with persons from database (DB.myPersons)
            person.GetPersons();

            // create local list to be accessed via @Model 
            foreach (var person in person.myPersons)
            {
                myPersons.Add(person);
            }
        }
    }
}