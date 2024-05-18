using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class ViewStudentsModel : PageModel
    {
        private DB _db;
        public DataTable dt = new DataTable();
        public ViewStudentsModel()
        {
            _db = new DB();
        }

        public void OnGet()
        {
            dt=_db.getstudents(HttpContext.Session.GetString("ccode"), _db.getsemester());
        }
    }
}
