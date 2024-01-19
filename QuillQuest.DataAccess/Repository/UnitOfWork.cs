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
        public IProductRepository ProductRepository { get; private set; }
        public ICompanyRepository CompanyRepository { get; private set; }
        public IShoppingCartRepository ShoppingCartRepository { get; private set; }
		public IApplicationUserRepository ApplicationUserRepository { get; private set; }
        public IOrderHeaderRepository OrderHeaderRepository { get; private set; }
        public IOrderDetailRepository OrderDetailRepository { get; private set; }

        public UnitOfWork(QuillQuestDbContext context)
		{
			_dbContext = context;
			CategoryRepository = new CategoryRepository(context);
            ProductRepository = new ProductRepository(context);
			CompanyRepository = new CompanyRepository(context);
            ShoppingCartRepository = new ShoppingCartRepository(context);
			ApplicationUserRepository = new ApplicationUserRepository(context);
            OrderHeaderRepository = new OrderheaderRepository(context);
			OrderDetailRepository = new OrderDetailRepository(context);
        }
		

		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}
