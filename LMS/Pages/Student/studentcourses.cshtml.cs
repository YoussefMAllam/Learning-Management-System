using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.Student
{
    public class studentcoursesModel : PageModel
    {
        private DB _db;
        public bool filter { get; set; } = false;
        public DataTable dt { get; set; }
        public DataTable dt1 { get; set; }
        public string id { get; set; }
        public studentcoursesModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            id = HttpContext.Session.GetString("ID");
            dt = _db.getRegisteredCourses(id, _db.getsemester());
        }
        public IActionResult OnPostShowCourses(string all, string CCode, string CName, string Sem)
        {
            filter = true;
            if(string.IsNullOrWhiteSpace(all))
            {
                if (!string.IsNullOrWhiteSpace(CCode))
                {
                    dt1 = _db.getRegisteredAndCodeCourses(id, _db.getsemester(), CCode);
                    return RedirectToPage("./studentcourses", new { dt1 ,filter});
                }
                else if(!string.IsNullOrWhiteSpace(CName)){
                    dt1 = _db.getRegisteredAndNameCourses(id, _db.getsemester(), CName);
                    return RedirectToPage("./studentcourses", new { dt1, filter });
                }
                else
                {
                    dt1=_db.getRegisteredCourses(id,_db.getsemester());
                    return RedirectToPage("./studentcourses", new { dt1, filter });
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(CCode))
                {
                    if (!string.IsNullOrWhiteSpace(Sem))
                    {
                        dt1 = _db.getByCodeandSemesterCourses(CCode,Sem);
                        return RedirectToPage("./studentcourses", new { dt1, filter });
                    }
                    else
                    {
                        dt1 = _db.getByCodeCourses(CCode);
                        return RedirectToPage("./studentcourses", new { dt1, filter });
                    }
                }
                else if (!string.IsNullOrWhiteSpace(CName))
                {
                    if (!string.IsNullOrWhiteSpace(Sem))
                    {
                        dt1 = _db.getByNameandSemesterCourses(CName,Sem);
                        return RedirectToPage("./studentcourses", new { dt1, filter });
                    }
                    else
                    {
                        dt1 = _db.getByNameCourses(CName);
                        return RedirectToPage("./studentcourses", new { dt1, filter });
                    }
                }
                else
                {
                    dt1 = _db.getAllCourses();
                    return RedirectToPage("./studentcourses", new { dt1, filter });
                }
            }
        }
    }
}

