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

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = Guid.Parse("72b1d6c1-cd17-4299-a700-db1ec9c60f3a"),
                    Name = "Tech Solution",
                    StreetAddress = "123 Tech St",
                    City = "Tech City",
                    PostalCode = "12121",
                    State = "IL",
                    PhoneNumber = "6669990000"
                },
                new Company
                {
                    Id = Guid.Parse("60812648-064a-4bff-94cd-de5ac60de991"),
                    Name = "Vivid Books",
                    StreetAddress = "999 Vid St",
                    City = "Vid City",
                    PostalCode = "66666",
                    State = "IL",
                    PhoneNumber = "7779990000"
                },
                new Company
                {
                    Id = Guid.Parse("40df0e0d-5e64-4051-990b-60d5a9718ce7"),
                    Name = "Readers Club",
                    StreetAddress = "999 Main St",
                    City = "Lala land",
                    PostalCode = "99999",
                    State = "NY",
                    PhoneNumber = "1113335555"
                }
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
                        ImageUrl = "\\images\\product\\333ef4f7-fcff-405e-b1c9-12b93f761af4.jpg"
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
						ImageUrl = "\\images\\product\\9c3c9229-e77b-49d3-9178-745b2650f41d.jpg"
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
						ImageUrl = "\\images\\product\\966885ea-fa5c-4d4c-8d1b-717d49bf2abe.jpg"
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
						ImageUrl = "\\images\\product\\08291c8d-90d6-407f-a7d2-8f5f10f0eee4.jpg"
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
						ImageUrl = "\\images\\product\\d995464f-3e24-4283-bb74-d52c9f7fa470.jpg"
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
						ImageUrl = "\\images\\product\\fd9fcccf-75ad-4305-960f-9e776c080d3c.jpg"
                    }
                );
        }
    }
}
