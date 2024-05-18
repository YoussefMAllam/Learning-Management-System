using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class AssignmentsManagerModel : PageModel
    {
        private DB _db;
        public DataTable _assignments = new DataTable();
        public AssignmentsManagerModel()
        {
            _db = new DB();
        }
        public string ccode { get; set; }
        public string sem { get; set; }
        public  string Aname { get; set; }
        public void OnGet()
        {
            ccode = HttpContext.Session.GetString("ccode");
            sem = HttpContext.Session.GetString("sem");
            _assignments = _db.getallcourseassignments(ccode, sem);
        }

        public IActionResult OnPostSelect(string aname)
        {
            Aname = aname;
            ccode= HttpContext.Session.GetString("ccode");
            sem= HttpContext.Session.GetString("sem");
            HttpContext.Session.SetString("aname", aname);
            return RedirectToPage("./IndividualassignmentTeacher", new { ccode, sem, aname=Aname});
        }

    }
}
