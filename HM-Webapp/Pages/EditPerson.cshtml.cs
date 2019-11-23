using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;
using System;

namespace Hej_Morsan_Projekt.Pages
{
    public class EditPersonModel : PageModel
    {
        // instantiate class
        Person person = new Person();

  // OnGet looks for 
        public void OnGet(string id, string name, string birthday, string counter)
        {
        }

        // public void OnGet()
        // {
        //     // gets id on delete button
        //     int id = Convert.ToInt32(Request.Query["id"]);
        //     string name = Request.Query["name"];
        //     string birthday = Request.Query["birthday"];
        //     int counter = Convert.ToInt32(Request.Query["counter"]);

        //     person.UpdatePerson(id, name, birthday, counter);
        // }
    }
}