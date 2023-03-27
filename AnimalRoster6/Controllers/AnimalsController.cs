using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalRoster6.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalRoster6.Controllers
{
    public class AnimalsController : Controller
    {

        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.animals = AnimalData.GetAll();
            return View();
        }

        [HttpGet]
        [Route("Animals/Add")]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        [Route("Animals/Add")]
        public IActionResult Add(Animal newAnimal)
        {
            AnimalData.Add(newAnimal);

            return Redirect("/Animals");
        }
    }
}

