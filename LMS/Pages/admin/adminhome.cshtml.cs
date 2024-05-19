using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace LMS.Pages.admin
{
    public class adminhomeModel : PageModel
    {
        private DB _db;
        public adminhomeModel()
        {
            _db = new DB();
        }    
        public void OnGet()
        {

        }
        public IActionResult OnPostAddStudent(string name, string id, string major, string batch, string email, string password) {
            _db.AddStudent(id,name, major, batch, email, password);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostAddInstructor(string id, string name, string email, string password)
        {
            _db.AddInstructor(id, name,email, password);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostRemoveStudent(string id)
        {
            _db.RemoveStudent(id);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostRemoveInstructor(string id)
        {
            _db.RemoveInstructor(id);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostAddCourse(string CCode, string CName, string Prereqs, string credits)
        {
            _db.AddCourse(CCode, CName, Prereqs, credits);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostAddAdmin(string email, string password, string id)
        {
            _db.AddAdmin(email, password, id);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostRemoveAdmin(string id)
        {
            _db.RemoveAdmin(id);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostAddCourseInstance(string ccode, string semester, string id)
        {
            _db.AddCourseInstance(ccode, semester, id);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostRemoveCourse(string ccode)
        {
            _db.RemoveCourse(ccode);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostRemoveCourseInstance(string ccode, string semester, string id)
        {
            _db.RemoveCourseInstance(ccode, semester, id);
            return RedirectToPage("./adminhome");
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("ID");
            return RedirectToPage("/Index");
        }
    }
}
