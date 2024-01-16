﻿using QuillQuest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.DataAccess.Repository.Interface
{
	public interface IApplicationUserRepository : IRepository<ApplicationUser>
	{
		void Update(ApplicationUser user);
	}
}
