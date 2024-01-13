using ArtGallery.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Category> categories { get; set; }
		public DbSet<Art> arts { get; set; }

		public DbSet<ApplicationUser> applicationUsers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Ethiopian-Art" },
				new Category { Id = 2, Name = "Photograph" },
				new Category { Id = 3, Name = "3D-Art" }
				);
			modelBuilder.Entity<Art>().HasData(
			  new Art { Id = 1, Title = "Art1", Artist = "Kidus-Workneh", Description = "A new form of art", CategoryId = 1, Imageurl = "" },
			  new Art { Id = 2, Title = "Art2", Artist = "Abenezer-Daniel", Description = "A new form of art", CategoryId = 2, Imageurl = "" },
			  new Art { Id = 3, Title = "Art3", Artist = "Urael-Alemayehu", Description = "A new form of art", CategoryId = 3, Imageurl = "" },
			  new Art { Id = 4, Title = "Art4", Artist = "Ayesha-Abduljelil", Description = "A new form of art", CategoryId = 2, Imageurl = "" },
			  new Art { Id = 5, Title = "Art5", Artist = "Lucy", Description = "A new form of art", CategoryId = 1, Imageurl = "" }
			  );
		}
	}
}
