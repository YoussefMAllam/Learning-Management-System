using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Xml.Linq;

namespace LMS.Pages.Student
{
    public class studentcoursesModel : PageModel
    {
        private DB _db;
        public string filter { get; set; }
        public DataTable dt { get; set; }
        public DataTable dt1 { get; set; }
        public string id { get; set; }
        public string MyProperty { get; set; }
        public studentcoursesModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            filter = HttpContext.Session.GetString("filter");
            id = HttpContext.Session.GetString("ID");
            if (string.IsNullOrWhiteSpace(filter))
                dt = _db.Getstudentcourses(id);
            {
                switch (HttpContext.Session.GetInt32("n"))
                {
                    case 1:
                        dt = _db.getRegisteredAndCodeCourses(id, _db.getsemester(), HttpContext.Session.GetString("CCode"));
                        break;
                    case 2:
                        dt = _db.getRegisteredAndNameCourses(id, _db.getsemester(), HttpContext.Session.GetString("CName"));
                        break;
                    case 3:
                        dt = _db.getRegisteredCourses(id, _db.getsemester());
                        break;
                    case 4:
                        dt = _db.getByCodeandSemesterCourses(HttpContext.Session.GetString("CCode"), HttpContext.Session.GetString("Sem"));
                        break;
                    case 5:
                        dt = _db.getByCodeCourses(HttpContext.Session.GetString("CCode"));
                        break;
                    case 6:
                        dt = _db.getByNameandSemesterCourses(HttpContext.Session.GetString("CName"), HttpContext.Session.GetString("Sem"));
                        break;
                    case 7:
                        dt = _db.getByNameCourses(HttpContext.Session.GetString("CName"));
                        break;
                    case 8:
                        dt = _db.getAllCourses();
                        break;
                }
            }
        }
        public IActionResult OnPostSelect(string coursedata)
        {
            MyProperty = coursedata;
            HttpContext.Session.SetString("ccode",_db.getccode(coursedata).Rows[0][0].ToString());
            HttpContext.Session.SetString("sem",_db.getsemester());
            return RedirectToPage("./coursehome");
        }
        public IActionResult OnPostShowCourses(string all, string CCode, string CName, string Sem)
        {
            HttpContext.Session.SetString("filter", "a");
            if (string.IsNullOrEmpty(CCode)) HttpContext.Session.SetString("CCode", " "); else HttpContext.Session.SetString("CCode", CCode);
            if (string.IsNullOrEmpty(CName)) HttpContext.Session.SetString("CName", " "); else HttpContext.Session.SetString("CCode", CName);
            if (string.IsNullOrEmpty(Sem)) HttpContext.Session.SetString("Sem", " "); else HttpContext.Session.SetString("CCode", Sem);
            if (string.IsNullOrWhiteSpace(all))
            {
                if (!string.IsNullOrWhiteSpace(CCode))
                {
                    HttpContext.Session.SetInt32("n", 1);
                    return RedirectToPage("./studentcourses");
                }
                else if (!string.IsNullOrWhiteSpace(CName))
                {
                    HttpContext.Session.SetInt32("n", 2);
                    return RedirectToPage("./studentcourses");
                }
                else
                {
                    HttpContext.Session.SetInt32("n", 3);
                    return RedirectToPage("./studentcourses");
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(CCode))
                {
                    if (!string.IsNullOrWhiteSpace(Sem))
                    {
                        HttpContext.Session.SetInt32("n", 4);
                        return RedirectToPage("./studentcourses");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("n", 5);
                        return RedirectToPage("./studentcourses");
                    }
                }
                else if (!string.IsNullOrWhiteSpace(CName))
                {
                    if (!string.IsNullOrWhiteSpace(Sem))
                    {
                        HttpContext.Session.SetInt32("n", 6);
                        return RedirectToPage("./studentcourses");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("n", 7);
                        return RedirectToPage("./studentcourses");
                    }
                }
                else
                {
                    HttpContext.Session.SetInt32("n",8);
                    return RedirectToPage("./studentcourses");
                }
            }
        }
    }
}

