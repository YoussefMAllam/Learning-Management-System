using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using System.Data;

namespace LMS.Pages.admin
{
    public class adminModel : PageModel
    {
        private DB _db;
        public DataTable _students;
        public adminModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            _students = _db.getAllStudents();
        }
        public IActionResult OnPostChangePassword(string id,string password)
        {
            _db.ChangeStudentPassword(id, password);
            return RedirectToPage("./student");
        }
    }
}
