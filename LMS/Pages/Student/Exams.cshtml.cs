using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMS.Pages.Student
{
    public class ExamsModel : PageModel
    {
        public List<Exam> Exams { get; set; }
        public void OnGet()
        {
            Exams = new List<Exam>
        {
            new Exam
            {
                Id = 1,
                CourseName = "Introduction to Computer Science",
                Venue = "Lecture Hall 1",
                Date = DateTime.Now,
                
            }
        };
        }
    }
}
    public class Exam
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string Venue { get; set; }
    public DateTime Date { get; set; }
  
}