using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.admin
{
    public class teacherModel : PageModel
    {
        private DB _db;
        public DataTable _admins;
        teacherModel()
        { 
            _db=new DB();
        }  
        public void OnGet()
        {
            _admins = _db.getAllInstructors();
        }
        public IActionResult OnPostChangePassword(string id, string password)
        {
            _db.ChangeInstructorPassword(id, password);
            return RedirectToPage("./student");
        }
    }
}
