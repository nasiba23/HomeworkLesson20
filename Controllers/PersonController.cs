using System.Threading.Tasks;
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
        public IActionResult Create(Person model)
        {
            _db.Create(model);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SearchId()
        {
            return View();
        }

        public IActionResult GetById(int Id)
        {
            var person = _db.SearchId(Id);
            return View("SearchId", person);
        }
    }
}