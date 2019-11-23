using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;
using System;

namespace Hej_Morsan_Projekt.Pages
{
    public class DeletePersonModel : PageModel
    {
        public string Id { get; private set; }

        // instantiate class
        Person person = new Person();

        public void OnGet()
        {
            // gets id on delete button
            Id = Request.Query["id"];

            person.DeletePerson(Convert.ToInt32(Id));
        }
    }
}