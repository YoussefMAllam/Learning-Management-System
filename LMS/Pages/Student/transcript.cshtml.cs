using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class transcriptModel : PageModel
    {
        public string id { get; set; }
        private DB _db;
        public DataTable TranscriptData { get; set; }
        public double GPA { get; set; }
        public void OnGet()
        {
            id = HttpContext.Session.GetString("ID");
            TranscriptData = _db.Getstudenttranscript(id);
            GPA = _db.calculateGPA(id);

        }
        

        public transcriptModel()
        {
            _db = new DB();
        }
    }
}
