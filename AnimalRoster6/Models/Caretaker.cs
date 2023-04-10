using System;
namespace AnimalRoster6.Models
{
	public class Caretaker
	{
		public int Id { get; set; }
		public string? Name { get; set; }

		public Caretaker()
		{
		}

		public Caretaker(string name)
		{
			Name = name;
		}
	}
}

