using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LMS.Models;
using Microsoft.AspNetCore.Session;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace LMS.Pages.Student
{
    public class coursehomeModel : PageModel
    {
        private DB _db;

        public coursehomeModel()
        {
            _db = new DB();
        }
    }
}


