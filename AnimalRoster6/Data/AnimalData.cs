using System;
using Microsoft.Extensions.Logging;

namespace AnimalRoster6.Models
{
	public class AnimalData
	{
		static private Dictionary<int, Animal> Animals = new Dictionary<int, Animal>();

        // GetAll
        public static IEnumerable<Animal> GetAll()
        {
            return Animals.Values;
        }

        // Add
        public static void Add(Animal newAnimal)
        {
            Animals.Add(newAnimal.Id, newAnimal);
        }

        // Remove
        public static void Remove(int id)
        {
            Animals.Remove(id);
        }

        // GetById
        public static Animal GetById(int id)
        {
            return Animals[id];
        }
    }
}

