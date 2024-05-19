using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Student
{
    public class ForumModel : PageModel
    {
        private DB _db;
        public DataTable dt = new DataTable();
        public ForumModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            dt = _db.getthreads();
        }

        public IActionResult OnPostView(string thread, string ccode)
        {
            HttpContext.Session.SetString("th", thread);
            HttpContext.Session.SetString("ccode", ccode);
            return RedirectToPage("./ForumPage", new { title = thread, cocode = ccode });
        }

        public IActionResult OnPostAdd(string ccode, string title, string question)
        {
            return RedirectToPage("./AddForumPage");
        }
    }
}
