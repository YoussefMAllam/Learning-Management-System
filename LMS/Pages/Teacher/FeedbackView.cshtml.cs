using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class FeedbackViewModel : PageModel
    {
        public DataTable dt=new DataTable();
        private DB _db;
        public FeedbackViewModel()
        {
            _db = new DB();
        }

        public void OnGet()
        {
            dt=_db.getfeedback(HttpContext.Session.GetString("ccode"), _db.getsemester());
        }
    }
}
