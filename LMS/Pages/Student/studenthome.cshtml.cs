using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Pages.Student
{
    public class studenthomeModel : PageModel
    {
        public string id { get; set; }

        public void OnGet()
        {
            id= HttpContext.Session.GetString("ID");

        }
    }
}
