using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalRoster6.Models;
using AnimalRoster6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AnimalRoster6.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalRoster6.Controllers
{
    public class AnimalsController : Controller
    {
        private AnimalDbContext context;
        public AnimalsController(AnimalDbContext dbContext)
        {
            context = dbContext;
        }


        [HttpGet]
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Animal> animals = context.Animals.ToList();
            return View(animals);
        }

        [HttpGet]
        [Route("Animals/Add")]
        public IActionResult Add()
        {
            AddAnimalViewModel addAnimalViewModel = new AddAnimalViewModel();
            return View(addAnimalViewModel);
        }


        [HttpPost]
        [Route("Animals/Add")]
        public IActionResult Add(AddAnimalViewModel addAnimalViewModel)
        {
            if (ModelState.IsValid)
            {
                Animal newAnimal = new Animal
                {
                    Name = addAnimalViewModel.Name,
                    Species = addAnimalViewModel.Species,
                    Description = addAnimalViewModel.Description,
                    Handler = addAnimalViewModel.Handler,
                    ImgUrl = addAnimalViewModel.ImgUrl
                };

                context.Animals.Add(newAnimal);
                context.SaveChanges();

                return Redirect("/Animals");
            }

            return View(addAnimalViewModel);

        }
    }
}

