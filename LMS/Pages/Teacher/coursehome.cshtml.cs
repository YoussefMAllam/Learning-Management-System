using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;


namespace LMS.Pages.Teacher
{
    public class coursehomeModel : PageModel
    {
        private DB _db;
        public DataTable _material = new DataTable();
        public coursehomeModel()
        {
            _db = new DB();
        }
        public string ccode { get; set; }
        public string sem { get; set; }
        public string coursename { get; set; }
        public void OnGet()
        {
            ccode = HttpContext.Session.GetString("ccode");
            sem = HttpContext.Session.GetString("sem");
            coursename = _db.getcoursename(ccode).Rows[0][0].ToString();
            _material = _db.getmaterial(ccode);
        }

        public IActionResult OnPostStudent(string email)
        {
            string id= _db.get_ID(email).Rows[0][0].ToString();
            ccode=HttpContext.Session.GetString("ccode");
            sem=HttpContext.Session.GetString("sem");
            _db.registerstudent(ccode,sem,id);
            return RedirectToPage("./coursehome");
        }
        public IActionResult OnPostAssignment(string title, string link, string date,string descript)
        {
            ccode=HttpContext.Session.GetString("ccode");
            sem=HttpContext.Session.GetString("sem");
            _db.addassignment(ccode,sem,title,date,descript);
            return RedirectToPage("./coursehome");
        }

        public IActionResult OnPostAnnouncement(string title, string description)
        {
            ccode=HttpContext.Session.GetString("ccode");
            sem=HttpContext.Session.GetString("sem");
            _db.addannouncement(ccode,sem,title,description);
            return RedirectToPage("./coursehome");
        }

        public IActionResult OnPostMaterial(string title, string link)
        {
            ccode=HttpContext.Session.GetString("ccode");
            sem=HttpContext.Session.GetString("sem");
            _db.addmaterial(ccode,title,link);
            return RedirectToPage("./coursehome");
        }

        public IActionResult OnPostViewAssignments()
        {
            return RedirectToPage("./AssignmentsManager");
        }

        public IActionResult OnPostViewExams()
        {
            return RedirectToPage("./ExamManager");
        }

        public IActionResult OnPostFinalGrade()
        {
            return RedirectToPage("./FinalGrade");
        }

        public IActionResult OnPostViewFeedback()
        {
            return RedirectToPage("./FeedbackView");
        }

        public IActionResult OnPostViewStudents()
        {
            return RedirectToPage("./ViewStudents");
        }
    }
}
