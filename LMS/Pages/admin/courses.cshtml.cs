using LMS.Models;
using LMS.Models.Charts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data;

namespace LMS.Pages.admin
{
    public class coursesModel : PageModel
    {
        private DB _db;
        public string MyProperty { get; set; }
        public DataTable _courses { get; set; }
        public ChartJS BarChart { get; set; }
        public string ChartJson { get; set; }
        public coursesModel() 
        {
            _db = new DB();
            BarChart = new ChartJS();
        }
        private void setUpBarChart(Dictionary<string, int> dataToDisplay)
        {
            try
            {
                // 1. set up chart options
                BarChart.type = "pie";
                BarChart.options.responsive = true;
                // 2. separate the received Dictionary data into labels and data arrays
                var labelsArray = new List<string>();
                var dataArray = new List<double>();
                foreach (var data in dataToDisplay)
                {
                    labelsArray.Add(data.Key);
                    dataArray.Add(data.Value);
                }
                BarChart.data.labels = labelsArray;
                // 3. set up a dataset
                var firsDataset = new Dataset();
                firsDataset.label = "Number of courses from each department";
                firsDataset.data = dataArray.ToArray();
                BarChart.data.datasets.Add(firsDataset);
                // 4. finally, convert the object to json to be able to inject in  HTML code

                ChartJson = JsonConvert.SerializeObject(BarChart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initialising the bar chart inside Index.cshtml.cs");
                throw e;
            }
        }
        public void OnGet()
        {
            Dictionary<string, int> CoursesByMajor = _db.getNumberofCoursesinMajor();
            setUpBarChart(CoursesByMajor);
            _courses = _db.AgetAllCourses();
        }
        public IActionResult OnPostSelect(string coursedata)
        {
            MyProperty = coursedata;
            HttpContext.Session.SetString("ccode", _db.getccode(coursedata).Rows[0][0].ToString());
            string ccode = HttpContext.Session.GetString("ccode");
            string sem = HttpContext.Session.GetString("sem");
            return RedirectToPage("./coursedetails", new { ccode, sem });
        }
    }
}
