using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class IndividualCourseTeacherModel : PageModel
    {
        private DB _db;
        public DataTable _assignments = new DataTable();
        [BindProperty(SupportsGet = true)]
        public string aname { get; set; }

        public string ccode { get; set; }
        public string sem { get; set; }
        public IndividualCourseTeacherModel()
        {
            _db = new DB();
        }


        public void OnGet()
        {
            HttpContext.Session.SetString("aname", aname);
            ccode= HttpContext.Session.GetString("ccode");
            sem= HttpContext.Session.GetString("sem");
            _assignments=_db.getassignmentsub(aname,HttpContext.Session.GetString("ccode"), HttpContext.Session.GetString("sem"));

        }

        public IActionResult OnPostDone(string ID, string grade)
        {
            aname= HttpContext.Session.GetString("aname");
            _db.gradeassignment(aname,HttpContext.Session.GetString("ccode"),_db.getsemester(),ID, grade);
            return RedirectToPage("./IndividualAssignmentTeacher", new {ccode,sem,aname=this.aname});
        }
    }
}
