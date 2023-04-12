using System;
namespace AnimalRoster6.Models
{
	public class AnimalCaretaker
    {
		public int Id { get; set; }
		public string? Name { get; set; }

		public List<Animal> Animals { get; set; }

		public AnimalCaretaker()
		{
		}

		public AnimalCaretaker(string name)
		{
			Name = name;
		}
	}
}

