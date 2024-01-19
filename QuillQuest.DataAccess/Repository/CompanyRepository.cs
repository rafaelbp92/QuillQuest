using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Enums;
using QuillQuest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.DataAccess.Repository
{

    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly QuillQuestDbContext _dbContext;

        public CompanyRepository(QuillQuestDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public void Update(Company company)
        {
            _dbContext.Companies.Update(company);
        }
    }
}
