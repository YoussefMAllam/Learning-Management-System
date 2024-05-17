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
        public studenthomeModel()
        {
            _db = new DB();
        }

        public List<Task> Tasks { get; set; }
          

        

        public IActionResult OnPostAddTask(string task, string ccode, string sem)
        {
            _db.AddTodo(id, task, ccode, sem);
            return RedirectToPage("./studenthome");
        }
        public string id { get; set; }

        public void OnGet()
        {
            dt = _db.ViewTasks(id);

            id = HttpContext.Session.GetString("ID");

        }
        
    }
    public class Task
    {
        public int StId { get; set; }
        public string Task1 { get; set; }
        public string CourseCode { get; set; }
        public string Semester { get; set; }
        public bool Done { get; set; }
    }


}

   

