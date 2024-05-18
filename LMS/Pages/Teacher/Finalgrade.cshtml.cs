using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;
namespace LMS.Pages.Teacher
{
    public class FinalgradeModel : PageModel
    {
        private DB _db;
        public DataTable _dt;


        public FinalgradeModel() {
            _db = new DB();
        }
        public void OnGet()
        {
            _dt=_db.getexaminedstudents(HttpContext.Session.GetString("ccode"),_db.getsemester());
        }
        
        public IActionResult OnPostFinal(string id, string grade)
        {
            _db.addtranscript(HttpContext.Session.GetString("ccode"), _db.getsemester(),id, grade);
            return RedirectToPage("./Finalgrade");
        }

    }
}
