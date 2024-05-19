using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.Student
{
    public class studentcoursesModel : PageModel
    {
        private DB _db;
        public bool filter { get; set; } = false;
        public DataTable dt { get; set; }
        public DataTable dt1 { get; set; }
        public string id { get; set; }
        public string MyProperty { get; set; }
        public studentcoursesModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            id = HttpContext.Session.GetString("ID");
            dt = _db.getRegisteredCourses(id, _db.getsemester());
        }
        public IActionResult OnPostSelect(string coursedata)
        {
            MyProperty = coursedata;


            HttpContext.Session.SetString("ccode",_db.getccode(coursedata).Rows[0][0].ToString());
            HttpContext.Session.SetString("sem",_db.getsemester());
            return RedirectToPage("./coursehome");
        }

    }
}

