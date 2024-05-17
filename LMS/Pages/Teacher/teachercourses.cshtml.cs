using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Teacher
{
    public class teachercoursesModel : PageModel
    {
        private DB _db;
        public  string ID { get; set; }
        public DataTable dt = new DataTable();
        public  string MyProperty { get; set; }
        public teachercoursesModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            ID =HttpContext.Session.GetString("ID");
            dt=_db.getIcourses(ID);
        }
        public void OnPostSelect(string coursedata)
        {
            MyProperty = coursedata;
            HttpContext.Session.SetString("ccode", _db.getccode(coursedata).Rows[0][0].ToString());
            HttpContext.Session.SetString("sem", _db.getsemester());
            string ccode= HttpContext.Session.GetString("ccode");
            string sem= HttpContext.Session.GetString("sem");
        }
    }
}
