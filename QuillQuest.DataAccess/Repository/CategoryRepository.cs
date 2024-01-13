using Microsoft.EntityFrameworkCore;
using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;

namespace QuillQuest.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly QuillQuestDbContext _dbContext;

		public CategoryRepository(QuillQuestDbContext context) : base(context) 
		{
			_dbContext = context;
		}

		public void Update(Category category)
		{
			_dbContext.Categories.Update(category);
		}
	}
}
