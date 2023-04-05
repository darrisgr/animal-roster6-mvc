using System;
using AnimalRoster6.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalRoster6.Data
{
	public class AnimalDbContext : DbContext
	{
		public DbSet<Animal> Animals { get; set; }

		public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
		{
		}
	}
}

