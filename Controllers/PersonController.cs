using HomeworkLesson20.DbContext;
using HomeworkLesson20.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkLesson20.Controllers
{
    public class PersonController: Controller
    {
        private IDatabaseService _db;

        public PersonController(IDatabaseService db)
        {
            _db = db;
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}