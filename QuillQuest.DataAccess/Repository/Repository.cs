using Microsoft.EntityFrameworkCore;
using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace QuillQuest.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly QuillQuestDbContext _dbContext;
		internal DbSet<T> dbSet;

        public Repository(QuillQuestDbContext context)
        {
            _dbContext	= context;
			dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach (var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(prop);
				}
			}
			return query.FirstOrDefault(filter);
		}

		public IEnumerable<T> GetAll(string? includeProperties = null)
		{
			IQueryable<T> query = dbSet;
			if (!string.IsNullOrEmpty(includeProperties))
			{
				foreach(var prop in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(prop);
				}
			}
			return query.ToList();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			dbSet.RemoveRange(entities);
		}
	}
}
