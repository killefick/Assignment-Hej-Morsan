using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;
using System;
namespace Hej_Morsan_Projekt.Pages
{
    public class ResetPersonModel : PageModel
    {
        // instantiate class
        Person person = new Person();

        public void OnGet()
        {
            // reads parameters for resetting person
            int id = Convert.ToInt32(Request.Query["id"]);
            int counter = Convert.ToInt32(Request.Query["counter"]);

            person.UpdateCounter(id, counter);
        }
    }
}