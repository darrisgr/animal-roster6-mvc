using AnimalRoster6.Models;

namespace AnimalRoster6.ViewModels
{
    public class AnimalDetailViewModel
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string Description { get; set; }
        public string Caretaker { get; set; }
        public string ImgUrl { get; set; }

        public AnimalDetailViewModel(Animal theAnimal)
        {
            Name = theAnimal.Name;
            Species = theAnimal.Species;
            Description = theAnimal.Description;
            Caretaker = theAnimal.Caretaker.Name;
            ImgUrl = theAnimal.ImgUrl;
        }
    }
}
