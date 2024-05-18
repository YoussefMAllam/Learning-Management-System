using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.admin
{
    public class coursedetailsModel : PageModel
    {
        private DB _db;
        public DataTable _courseinstances;
        public string ccode { get; set; }
        public string coursename { get; set; }
        public coursedetailsModel()
        {
            _db = new DB(); 
        }
        public void OnGet()
        {
            ccode = HttpContext.Session.GetString("ccode");
            coursename = _db.getcoursename(ccode).Rows[0][0].ToString();
            _courseinstances = _db.getCourseInstances(ccode);
        }
    }
}
