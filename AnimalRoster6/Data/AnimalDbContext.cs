using AnimalRoster6.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalRoster6.Data
{
	public class AnimalDbContext : DbContext
	{
		public DbSet<Animal> Animals { get; set; }
		public DbSet<AnimalCaretaker> Caretakers { get; set; }
		public DbSet<Tag> Tags { get; set; }

		public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Animal>()
				.HasMany(a => a.Tags)
				.WithMany(a => a.Animals)
				.UsingEntity(o =>
				o.ToTable("EventTags"));
        }
    }
}

