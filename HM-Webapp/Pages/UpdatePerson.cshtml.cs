using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Hej_Morsan_Projekt.Pages
{
    public class UpdatePersonModel : PageModel
    {
        // instantiate classes
        DB db = new DB();



        public void OnGet()
        {
            // Id = Convert.ToInt32(Request.Query["id"]);
            // Name = Request.Query["name"];
            // Phone = Request.Query["phone"];
            // Birthday = Request.Query["birthday"];
            // Counter = Convert.ToInt32(Request.Query["counter"]);

            // db.UpdatePersonOnDB(Id, Name, Phone, Birthday, Counter);
        }

        public void OnPost(int id, string name, string phone)
        {
            // var id = Request.Form["id"];
            // var name = Request.Form["name"];
            // var phone = Request.Form["phone"];
            // do something with emailAddress
        }
    }
}