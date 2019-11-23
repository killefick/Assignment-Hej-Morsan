using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;

namespace Hej_Morsan_Projekt.Pages
{
    public class EditPersonModel : PageModel
    {
        // instantiate class
        Person person = new Person();

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Birthday { get; private set; }
        public string Counter { get; private set; }

        public void OnGet()
        {
            Id = Request.Query["id"];
            Name = Request.Query["name"];
            Phone = Request.Query["phone"];
            Birthday = Request.Query["birthday"];
            Counter = Request.Query["counter"];
        }

    }
}