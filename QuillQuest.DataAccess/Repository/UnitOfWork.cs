using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly QuillQuestDbContext _dbContext;
		public ICategoryRepository CategoryRepository { get; private set; }

		public UnitOfWork(QuillQuestDbContext context)
		{
			_dbContext = context;
			CategoryRepository = new CategoryRepository(context);
		}
		

		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}
