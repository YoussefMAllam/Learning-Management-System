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
        public string ccode { get; set; }
        public string sem { get; set; }
        public string studentname { get; set; }
        public string coursename { get; set; }
        public string stID { get; set; } 

        public studenthomeModel()
        {
            _db = new DB();
        }

        public IActionResult OnPostAddTask(string task,string ccode,string sem)
        {
            
              stID = HttpContext.Session.GetString("ID");
           
            _db.AddTodo(stID, task, ccode, sem);
            
            return RedirectToPage("./studenthome");
        }

        public void OnGet()
        {
            id = HttpContext.Session.GetString("ID");

            dt = _db.ViewTasks(id);
            studentname = _db.getstudentname(id).Rows[0][0].ToString();
        }
       

        public IActionResult OnPostDeletetask( string taskname)
        {
            
            
                _db.Removetask(taskname, HttpContext.Session.GetString("ID"));
            

            return RedirectToPage("./studenthome");
        }
    }
}







