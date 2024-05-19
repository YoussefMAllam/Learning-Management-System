using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;


namespace LMS.Pages.Teacher
{
    public class ForumPageModel : PageModel
    {
        private DB _db;

        public DataTable dt = new DataTable();
        public DataTable daateuser = new DataTable();

        public  string date { get; set; }
        public string user { get; set; }
        public  string  question { get; set; }
        [BindProperty(SupportsGet = true)]
        public string title { get; set; }
        [BindProperty(SupportsGet = true)]
        public string cocode { get; set; }
        public ForumPageModel()
        {
            _db = new DB();
        }
 

        public void OnGet()
        {
            title = HttpContext.Session.GetString("th");
            dt = _db.getthreadcomments(HttpContext.Session.GetString("th"), HttpContext.Session.GetString("ccode"));
            daateuser = _db.getdatename(HttpContext.Session.GetString("th"), HttpContext.Session.GetString("ccode"));
            date = daateuser.Rows[0][0].ToString();
            user = daateuser.Rows[0][1].ToString();
            question = daateuser.Rows[0][2].ToString();
        }

        public IActionResult OnPostComment(string comm)
        {
            _db.addthreadentry(HttpContext.Session.GetString("th"), HttpContext.Session.GetString("ccode"), comm);
            return RedirectToPage("./ForumPage", new {title=this.title, cocode=this.cocode});
        }

    }
}
