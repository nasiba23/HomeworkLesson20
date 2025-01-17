﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HomeworkLesson20.DbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HomeworkLesson20.Models;
using Microsoft.Extensions.Configuration;

namespace HomeworkLesson20.Controllers
{
    public class HomeController : Controller
    {
        private IDatabaseService _db;

        public HomeController(IDatabaseService db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.GetList<Person>());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}