﻿using Microsoft.EntityFrameworkCore;
using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;

namespace QuillQuest.DataAccess.Repository
{
	public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		private readonly QuillQuestDbContext _dbContext;

		public ApplicationUserRepository(QuillQuestDbContext context) : base(context) 
		{
			_dbContext = context;
		}

		public void Update(ApplicationUser user)
		{
			_dbContext.ApplicationUsers.Update(user);
		}
	}
}
