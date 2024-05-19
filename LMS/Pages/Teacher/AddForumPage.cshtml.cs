using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class AddForumPageModel : PageModel
    {
        private DB _db;
        public AddForumPageModel() { 
            _db = new DB();
        }
        public void OnGet()
        {
        }

        public IActionResult OnPostAdd(string title, string ccode,string question) {
            string current_date = DateTime.Now.ToString();
            _db.Addthread(ccode,title,question,current_date);
            return RedirectToPage("./teacherforum");
        }
    }
}
