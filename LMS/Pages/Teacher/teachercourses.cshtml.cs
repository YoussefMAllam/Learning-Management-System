using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;

namespace LMS.Pages.Teacher
{
    public class teachercoursesModel : PageModel
    {
        private DB _db;
        public  string ID { get; set; }
        public DataTable dt = new DataTable();
        public teachercoursesModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            ID =HttpContext.Session.GetString("ID");
            dt=_db.getIcourses(ID);
        }
    }
}
