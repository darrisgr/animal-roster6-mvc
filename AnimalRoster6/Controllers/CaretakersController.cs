using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalRoster6.Data;
using AnimalRoster6.Models;
using AnimalRoster6.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalRoster6.Controllers
{
    public class CaretakersController : Controller
    {
        private AnimalDbContext context;
        public CaretakersController(AnimalDbContext dbContext)
        {
            context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<AnimalCaretaker> caretakers = context.Caretakers.ToList();
            return View(caretakers);
        }

        [Route("Caretakers/Add")]
        public IActionResult Add()
        {
            AddCaretakerViewModel addCaretakerViewModel = new AddCaretakerViewModel();
            return View(addCaretakerViewModel);
        }

        [HttpPost]
        [Route("Caretakers/Add")]
        public IActionResult Add(AddCaretakerViewModel addCaretakerViewModel)
        {
            if (ModelState.IsValid)
            {
                AnimalCaretaker newCaretaker = new AnimalCaretaker
                {
                    Name = addCaretakerViewModel.Name
                };

                context.Caretakers.Add(newCaretaker);
                context.SaveChanges();

                return Redirect("/Caretakers");
            }

            return View(addCaretakerViewModel);
        }
    }
}

