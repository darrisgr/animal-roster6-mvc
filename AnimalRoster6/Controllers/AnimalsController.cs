using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalRoster6.Models;
using AnimalRoster6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using AnimalRoster6.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            List<Animal> animals = context.Animals.Include(a => a.Caretaker).ToList();
            return View(animals);
        }

        [HttpGet]
        [Route("Animals/Add")]
        public IActionResult Add()
        {
            List<AnimalCaretaker> caretakers = context.Caretakers.ToList();
            AddAnimalViewModel addAnimalViewModel = new AddAnimalViewModel(caretakers);
            return View(addAnimalViewModel);
        }


        [HttpPost]
        [Route("Animals/Add")]
        public IActionResult Add(AddAnimalViewModel addAnimalViewModel)
        {
            if (ModelState.IsValid)
            {
                AnimalCaretaker theCaretaker = context.Caretakers.Find(addAnimalViewModel.CaretakerId);
                Animal newAnimal = new Animal
                {
                    Name = addAnimalViewModel.Name,
                    Species = addAnimalViewModel.Species,
                    Description = addAnimalViewModel.Description,
                    ImgUrl = addAnimalViewModel.ImgUrl,
                    Caretaker = theCaretaker
                };

                context.Animals.Add(newAnimal);
                context.SaveChanges();

                return Redirect("/Animals");
            }

            return View(addAnimalViewModel);

        }

        public IActionResult Remove()
        {
            ViewBag.animals = context.Animals.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] animalIds)
        {
            foreach (int animalId in animalIds)
            {
                Animal? theAnimal= context.Animals.Find(animalId);
                context.Animals.Remove(theAnimal);
            }

            context.SaveChanges();

            return Redirect("/Animals");
        }

        public IActionResult Detail(int id)
        {
            Animal theAnimal = context.Animals
               .Include(a => a.Caretaker)
               .Include(a => a.Tags)
               .Single(a => a.Id == id);

            AnimalDetailViewModel viewModel = new AnimalDetailViewModel(theAnimal);
            return View(viewModel);
        }
    }
}

