using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace LMS.Pages.Guest
{
    public class ViewmaterialcshtmlModel : PageModel
    {
        private DB _db;
        public DataTable _material = new DataTable();
       
        public string ccode { get; set; }
        
        public void OnGet()
        {
            _db = new DB();
            ccode = HttpContext.Session.GetString("ccode");
           
            _material = _db.getstudentmaterial(ccode);
        }
    }
}
