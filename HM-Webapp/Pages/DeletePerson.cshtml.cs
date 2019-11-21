using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;

namespace Hej_Morsan_Projekt.Pages
{
    public class DeletePersonModel : PageModel
    {
        public void OnGet()
        {
            var db = new DB("Server=40.85.84.155;Database=Student13;User=Student13;Password=YH-student@2019;");
            // ClassLibHejMorsan.Person.DeletePerson(2);
        }
    }
}