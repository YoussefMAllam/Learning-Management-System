using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class ExamManagerModel : PageModel
    {
        private DB _db;
        public ExamManagerModel() {
            _db = new DB();
        }

        public DataTable dt = new DataTable();
        public DataTable unattanded = new DataTable();
        public string avg { get; set; }
        public void OnGet()
        {
            dt = _db.getexamsub(HttpContext.Session.GetString("ccode"), HttpContext.Session.GetString("sem"));
            unattanded = _db.getunattended(HttpContext.Session.GetString("ccode"), HttpContext.Session.GetString("sem"));
            avg = _db.getexamavg(HttpContext.Session.GetString("ccode"), HttpContext.Session.GetString("sem")).Rows[0][0].ToString();
        }

        public IActionResult OnPostSend(string ID, string grade) {
            _db.gradeexam(HttpContext.Session.GetString("ccode"), _db.getsemester(), ID, grade);
            return RedirectToPage("./ExamManager");
        }

        public IActionResult OnPostCheck(string ID)
        {
            _db.addexamsub(HttpContext.Session.GetString("ccode"), _db.getsemester(), ID);
            return RedirectToPage("./ExamManager");
        }
    }
}
