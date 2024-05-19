using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Student
{
    public class coursehomeModel : PageModel
    {
        private DB _db;
        public DataTable temp=new DataTable();
        public string ccode { get; set; }
        public string sem { get; set; }
        public string coursename { get; set; }
        public string stID { get; set; }
        public DataTable _material = new DataTable();
        public DataTable _anouncements = new DataTable();
        public DataTable _assignments = new DataTable();
        public DataTable unsubmitted = new DataTable();
        public DataTable submitted = new DataTable();
        public coursehomeModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            ccode = HttpContext.Session.GetString("ccode");
            coursename=_db.getcoursename(ccode).Rows[0][0].ToString();
            
            sem = HttpContext.Session.GetString("sem");
         
            _material = _db.getstudentmaterial(ccode);
            _anouncements = _db.getanouncement(ccode, sem);
            _assignments = _db.Viewassignments(ccode, sem);
            unsubmitted=_db.getunsubmittedassignments(HttpContext.Session.GetString("ID"),ccode,sem);
            submitted = _db.getsubmittedassignments(HttpContext.Session.GetString("ID"), ccode, sem);

        }

        public IActionResult OnPostFeedback(string description)
        {  
            ccode = HttpContext.Session.GetString("ccode");
            stID = HttpContext.Session.GetString("ID");
           sem= HttpContext.Session.GetString("sem");
            _db.AddStudentfeedback(stID, ccode,description);
            return RedirectToPage("./coursehome");
        }

        public IActionResult OnPostAssignments( string Assignmentlink,string Aname)
        {
            ccode = HttpContext.Session.GetString("ccode");
            stID = HttpContext.Session.GetString("ID");
            sem = HttpContext.Session.GetString("sem");
            _db.Addassignmentsubmission(stID,ccode,Assignmentlink,Aname,sem);
            return RedirectToPage("./coursehome");
        }

        public IActionResult OnPostSubmitAssignment(string Assignmentlink,string Aname)
        {
            _db.Addassignmentsubmission(HttpContext.Session.GetString("ID"), HttpContext.Session.GetString("ccode"), Assignmentlink, Aname, _db.getsemester());
            return RedirectToPage("./coursehome");
        }
    }
}


