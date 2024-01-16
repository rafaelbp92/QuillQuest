using Microsoft.EntityFrameworkCore;
using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;

namespace QuillQuest.DataAccess.Repository
{
	public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
	{
		private readonly QuillQuestDbContext _dbContext;

		public ShoppingCartRepository(QuillQuestDbContext context) : base(context) 
		{
			_dbContext = context;
		}

		public void Update(ShoppingCart cart)
		{
			_dbContext.ShoppingCarts.Update(cart);
		}
	}
}
