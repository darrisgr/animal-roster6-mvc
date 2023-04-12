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
        public string TagText { get; set; }
        public int Id { get; }

        public AnimalDetailViewModel(Animal theAnimal)
        {
            Name = theAnimal.Name;
            Species = theAnimal.Species;
            Description = theAnimal.Description;
            Caretaker = theAnimal.Caretaker.Name;
            ImgUrl = theAnimal.ImgUrl;
            Id = theAnimal.Id;

            TagText = "";
            List<Tag> tags = theAnimal.Tags.ToList();

            for (int i = 0; i < tags.Count; i++)
            {
                TagText += ($"#{tags[i].Name}");
                if (i < tags.Count - 1)
                {
                    TagText += ", ";
                }
            }
        }
    }
}
