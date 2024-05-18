using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.Student
{
    public class ExamsModel : PageModel
    {
        public string id { get; set; }
        private DB _db;
        public DataTable ExamsData { get; set; }
        public void OnGet()
        {
            id = HttpContext.Session.GetString("ID");
            ExamsData = _db.getExams(id);


        }
        public ExamsModel()
        {
            _db = new DB();
        }
    }
}
  