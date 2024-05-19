using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using System.Data;


namespace LMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        [BindProperty]
        public string role { get; set; }



        private readonly DB db = new DB();
        public DataTable dt;
        public string ID;
        public IndexModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            this.db = db;
        }

        public void OnGet()
        {
            HttpContext.Session.SetString("filter", " ");
        }

        public IActionResult OnPost()
        {
            dt = db.getInstID(email, password);
            if (dt.Rows.Count == 0)
            {
                return RedirectToPage("Index");
            }
            ID = dt.Rows[0][0].ToString();
            if (dt.Rows.Count == 1)
            {
                if (ID.Length==3)
                {
                    HttpContext.Session.SetString("ID", ID);
                    return RedirectToPage("Teacher/teacherhome", new { id = ID });
                }
                else if (ID.Length==9)
                {
                    HttpContext.Session.SetString("ID", ID);
                    return RedirectToPage("Student/studenthome", new { id = ID });
                }
                else if (ID.Length==2||ID.Length==1)
                {
                    HttpContext.Session.SetString("ID", ID);
                    return RedirectToPage("Admin/adminhome", new { id = ID });
                }
            }

            return RedirectToPage("Index");
        }
    }
}
