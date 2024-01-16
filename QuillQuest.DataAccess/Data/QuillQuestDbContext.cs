using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuillQuest.Models.Models;

namespace QuillQuest.DataAccess.Data
{
    public class QuillQuestDbContext : IdentityDbContext
    {
        public QuillQuestDbContext(DbContextOptions<QuillQuestDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = Guid.Parse("FC591A53-7E51-4C33-B6F4-278DE977DD9C"), Name= "Action", DisplayOrder = 1 },
                    new Category { Id = Guid.Parse("9FA92E4C-D942-4F76-9B0D-7F8334791723"), Name = "SciFi", DisplayOrder = 2 },
                    new Category { Id = Guid.Parse("F7B462A5-8581-4B90-B009-05C316F0E691"), Name = "History", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Fortune of Time",
                        Author = "Billy Spark",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "SWD9999001",
                        ListPrice = 99,
                        Price = 90,
                        Price50 = 85,
                        Price100 = 80,
                        CategoryId = Guid.Parse("FC591A53-7E51-4C33-B6F4-278DE977DD9C"),
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Dark Skies",
                        Author = "Nancy Hoover",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "CAW777777701",
                        ListPrice = 40,
                        Price = 30,
                        Price50 = 25,
                        Price100 = 20,
						CategoryId = Guid.Parse("9FA92E4C-D942-4F76-9B0D-7F8334791723"),
						ImageUrl = ""
					},
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Vanish in the Sunset",
                        Author = "Julian Button",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "RITO5555501",
                        ListPrice = 55,
                        Price = 50,
                        Price50 = 40,
                        Price100 = 35,
						CategoryId = Guid.Parse("FC591A53-7E51-4C33-B6F4-278DE977DD9C"),
						ImageUrl = ""
					},
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Cotton Candy",
                        Author = "Abby Muscles",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "WS3333333301",
                        ListPrice = 70,
                        Price = 65,
                        Price50 = 60,
                        Price100 = 55,
						CategoryId = Guid.Parse("9FA92E4C-D942-4F76-9B0D-7F8334791723"),
						ImageUrl = ""
					},
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Rock in the Ocean",
                        Author = "Ron Parker",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "SOTJ1111111101",
                        ListPrice = 30,
                        Price = 27,
                        Price50 = 25,
                        Price100 = 20,
						CategoryId = Guid.Parse("F7B462A5-8581-4B90-B009-05C316F0E691"),
						ImageUrl = ""
					},
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Title = "Leaves and Wonders",
                        Author = "Laura Phantom",
                        Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                        ISBN = "FOT000000001",
                        ListPrice = 25,
                        Price = 23,
                        Price50 = 22,
                        Price100 = 20,
						CategoryId = Guid.Parse("9FA92E4C-D942-4F76-9B0D-7F8334791723"),
						ImageUrl = ""
					}
                );
        }
    }
}
