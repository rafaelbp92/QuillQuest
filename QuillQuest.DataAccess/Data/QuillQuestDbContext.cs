using Microsoft.EntityFrameworkCore;
using QuillQuest.Models.Models;

namespace QuillQuest.DataAccess.Data
{
    public class QuillQuestDbContext : DbContext
    {
        public QuillQuestDbContext(DbContextOptions<QuillQuestDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = Guid.NewGuid(), Name= "Action", DisplayOrder = 1 },
                    new Category { Id = Guid.NewGuid(), Name = "SciFi", DisplayOrder = 2 },
                    new Category { Id = Guid.NewGuid(), Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
