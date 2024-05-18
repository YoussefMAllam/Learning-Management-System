using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using LMS.Pages.Student;
using LMS.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

using Microsoft.AspNetCore.Session;
namespace LMS.Pages.Student
{
    public class studenthomeModel : PageModel
    {
        private DB _db;
        public DataTable dt { get; set; }
        public string id { get; set; }

        public studenthomeModel()
        {
            _db = new DB();
        }

        public IActionResult OnPostAddTask(string task, string ccode, string sem)
        {
            id = HttpContext.Session.GetString("ID");
            _db.AddTodo(id, task, ccode, sem);
            dt = _db.ViewTasks(id);
            return RedirectToPage("./studenthome");
        }

        public void OnGet()
        {
            id = HttpContext.Session.GetString("ID");
            dt = _db.ViewTasks(id);
        }
    }
}







