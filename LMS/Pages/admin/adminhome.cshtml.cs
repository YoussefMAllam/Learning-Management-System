using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Pages.admin
{
    public class adminhomeModel : PageModel
    {
        private DB _db;
        public void OnGet()
        {

        }
        public IActionResult OnPostAddStudent(string name, string id, string major, string batch, string email, string password) {
            _db.AddStudent(id,name, major, batch, email, password);
            return RedirectToPage("./adminhome");
        }
    }
}
