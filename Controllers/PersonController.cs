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

        public IActionResult GetById(int id)
        {
            var person = _db.SearchId(id);
            return View("SearchId", person);
        }

        public IActionResult SearchName()
        {
            return View();
        }

        public IActionResult GetByName(string name)
        {
            var names = name.Split(" ");
            var person = _db.SearchName(names[0], names[1], names[2]);
            return View("SearchName", person);
        }
    }
}