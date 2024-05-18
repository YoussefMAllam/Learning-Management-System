using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.admin
{
    public class coursesModel : PageModel
    {
        private DB _db;
        public string MyProperty { get; set; }
        public DataTable _courses { get; set; }
        public coursesModel() 
        {
            _db = new DB();
        }
        public void OnGet()
        {
            _courses = _db.AgetAllCourses();
        }
        public IActionResult OnPostSelect(string coursedata)
        {
            MyProperty = coursedata;
            HttpContext.Session.SetString("ccode", _db.getccode(coursedata).Rows[0][0].ToString());
            string ccode = HttpContext.Session.GetString("ccode");
            string sem = HttpContext.Session.GetString("sem");
            return RedirectToPage("./coursedetails", new { ccode, sem });
        }
    }
}
