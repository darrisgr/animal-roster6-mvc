using AnimalRoster6.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalRoster6.ViewModels
{
    public class AddAnimalTagViewModel
    {
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
        public int TagId { get; set; }
        public List<SelectListItem>? Tags { get; set; }

        public AddAnimalTagViewModel(Animal theAnimal, List<Tag> possibleTags)
        {
            Tags = new List<SelectListItem>();

            foreach (var tag in possibleTags)
            {
                Tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Name
                });
            }

            Animal = theAnimal;
        }

        public AddAnimalTagViewModel() { }
    }
}
