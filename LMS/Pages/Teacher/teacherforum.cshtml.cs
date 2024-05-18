using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class teacherforumModel : PageModel
    {
        private DB _db;
        public DataTable dt=new DataTable();
        public teacherforumModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            dt=_db.getthreads();
        }

        public IActionResult OnPostView(string thread,string ccode)
        {
            return RedirectToPage("./ForumPage", new { title = thread, cocode = ccode });
        }
    }
}
