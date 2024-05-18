using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.admin
{
    public class adminsModel : PageModel
    {
        private DB _db;
        public DataTable _admins;
        public adminsModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            _admins = _db.getAllAdmins();
        }
        public IActionResult OnPostChangePassword(string id, string password)
        {
            _db.ChangeAdminPassword(id, password);
            return RedirectToPage("./student");
        }
    }
}
