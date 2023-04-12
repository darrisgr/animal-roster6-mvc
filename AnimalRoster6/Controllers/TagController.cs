using AnimalRoster6.Data;
using AnimalRoster6.Models;
using AnimalRoster6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnimalRoster6.Controllers
{
    public class TagController : Controller
    {
        private AnimalDbContext context;

        public TagController(AnimalDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Tag> tags = context.Tags.ToList();
            return View(tags);
        }

        public IActionResult Add()
        {
            Tag tag = new Tag();
            return View(tag);
        }

        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tag);
                context.SaveChanges();
                return Redirect("/Tag/");
            }

            return View("Add", tag);
        }

        // localhost:[port]/Tag/AddAnimal/{AnimalId?}
        public IActionResult AddAnimal(int id)
        {
            Animal theAnimal = context.Animals.Find(id);
            List<Tag> possibleTags = context.Tags.ToList();

            AddAnimalTagViewModel viewModel = new AddAnimalTagViewModel(theAnimal, possibleTags);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddAnimal(AddAnimalTagViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                int animalId = viewModel.AnimalId;
                int tagId = viewModel.TagId;

                Animal theAnimal = context.Animals
                    .Include(a => a.Tags)
                    .Where(a => a.Id == animalId)
                    .First();

                Tag theTag = context.Tags
                    .Where(t => t.Id == tagId)
                    .First();

                theAnimal.Tags.Add(theTag);
                context.SaveChanges();
                return Redirect("/Animals/Detail/" + animalId);
            }

            return View(viewModel);
        }

        public IActionResult Detail(int id)
        {
            Tag theTag = context.Tags
                .Include(a => a.Animals)
                .Where(t => t.Id == id)
                .First();

            return View(theTag);
        }
    }
}