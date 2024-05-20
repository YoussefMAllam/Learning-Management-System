using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using LMS.Models.Charts;
using System.Data;
using Newtonsoft.Json;

namespace LMS.Pages.admin
{
    public class adminModel : PageModel
    {
        private DB _db;
        public DataTable _students;
        public ChartJS BarChart { get; set; }
        public string ChartJson { get; set; }
        public adminModel()
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
                firsDataset.label = "Number of students in each major";
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
            Dictionary<string, int> StudentsByMajor = _db.getNumberofStudentsinMajor();
            setUpBarChart(StudentsByMajor);
            _students = _db.getAllStudents();
        }
        public IActionResult OnPostChangePassword(string id,string password)
        {
            _db.ChangeStudentPassword(id, password);
            return RedirectToPage("./student");
        }
    }
}
