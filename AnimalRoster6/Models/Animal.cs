using System;
namespace AnimalRoster6.Models
{
	public class Animal
	{

        public string? Name { get; set; }
		public string? Species { get; set; }
		public string? Description { get; set; }
		public string? ImgUrl { get; set; }
        private static int nextId = 1;
        public int Id { get; }


        public Animal()
        {
            Id = nextId;
            nextId++;
        }

        public Animal(string name, string species, string description, string imgUrl)
        {
            Name = name;
            Species = species;
            Description = description;
            ImgUrl = imgUrl;
        }

        public override bool Equals(object? obj)
        {
            return obj is Animal animal &&
                   Id == animal.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return Name;
        }
    }
}

