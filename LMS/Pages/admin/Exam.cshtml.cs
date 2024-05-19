using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.admin
{
    public class ExamModel : PageModel
    {
        private DB _db;
        public ExamModel()
        {
            _db = new DB();
        }
        public DataTable setexams=new DataTable();
        public DataTable unsetexams=new DataTable();
        
        public void OnGet()
        {
            setexams=_db.getallexams();
            unsetexams = _db.tobesetexams();
        }

        public IActionResult OnPostAddexam(string ccode,string sem,string venue,string date)
        {
            _db.addexam(ccode, sem, venue, date);
            return RedirectToPage("./Exam");
        }
    }
}
