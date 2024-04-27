using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Pages.Student
{
    public class studenthomeModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Studentname { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<string> tasks { get; set; }

        public IActionResult OnPost(string id)
        {
            if (id == "Add Task")
            {
                return RedirectToPage("/add_task", new { AddTasks = tasks });
            }
            else
            {
                tasks.Remove(tasks[int.Parse(id)]);
                List<string> result = tasks;
                return RedirectToPage("/studenthome", new { tasks = result });
            }
        }

        public void OnGet()
        {

        }
    }
}
