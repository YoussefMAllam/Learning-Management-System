using Microsoft.Extensions.Options;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LMS.Models.Charts
{
    public class ChartJS
    {
        public ChartJS() 
        {
            options = new Options();
            data = new Data();
            title = new Title();
        }
        public string type { get; set; }
        public int duration { get; set; }
        public string easing { get; set; }
        public Title title { get; set; }
        public bool lazy { get; set; }
        public Data data { get; set; }
        public Options options { get; set; }
    }
}
