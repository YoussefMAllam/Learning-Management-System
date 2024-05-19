using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
namespace LMS.Pages.Teacher
{
    public class teacherhomeModel : PageModel
    {
        private DB _db;
        public DataTable dt { get; set; }
        public DataTable name { get; set; }    
        public teacherhomeModel()
        {
            _db = new DB();
        }
        public string id { get; set; }
        public void OnGet()
        {
            id=HttpContext.Session.GetString("ID");
            dt = _db.getungraded(id);
            name = _db.getInstructorName(id);
        }
    }
}
