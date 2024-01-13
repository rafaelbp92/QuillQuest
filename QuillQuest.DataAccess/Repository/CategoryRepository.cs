using Microsoft.EntityFrameworkCore;
using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private readonly QuillQuestDbContext _dbContext;

		public CategoryRepository(QuillQuestDbContext context) : base(context) 
		{
			_dbContext = context;
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}

		public void Update(Category category)
		{
			_dbContext.Categories.Update(category);
		}
	}
}
