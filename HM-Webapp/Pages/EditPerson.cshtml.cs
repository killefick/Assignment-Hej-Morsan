using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibHejMorsan;
using Microsoft.AspNetCore.Mvc;

namespace Hej_Morsan_Projekt.Pages
{
    public class EditPersonModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Id { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string Name { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string Phone { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string Birthday { get; private set; }

        [BindProperty(SupportsGet = true)]
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