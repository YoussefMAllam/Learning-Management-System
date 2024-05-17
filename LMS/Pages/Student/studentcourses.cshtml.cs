using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.Student
{
    public class studentcoursesModel : PageModel
    {
        private DB _db;
        public DataTable dt { get; set; }
        public string id { get; set; }
        public studentcoursesModel()
        {
            _db = new DB();
        }
        public void OnGet()
        {
            id = HttpContext.Session.GetString("ID");
        }
        public IActionResult OnPostShowCourses(bool registered, string CCode, string CName, string Sem)
        {
            if(registered)
            {
                if (CCode)
                {
                    dt=_db.getRegisteredAndCodeCourses(id,_db.)
                }
                else if{

                }
            }
            else
            {

            }
        }
    }
}

