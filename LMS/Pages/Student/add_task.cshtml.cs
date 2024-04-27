using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Pages.Student
{
    public class add_taskModel : PageModel
    {
        [BindProperty]
        public string new_task { get; set; }
        [BindProperty(SupportsGet = true)]
        public List<string> AddTasks { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            AddTasks.Add(new_task);
            return RedirectToPage("/studenthome", new { tasks = AddTasks });

        }
    }
}
