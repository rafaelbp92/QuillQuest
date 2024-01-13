using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;

namespace QuillQuest.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly QuillQuestDbContext _dbContext;

        public ProductRepository(QuillQuestDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public void Update(Product product)
        {
			var objFromDb = _dbContext.Products.FirstOrDefault(u => u.Id == product.Id);
			if (objFromDb != null)
			{
				objFromDb.Title = product.Title;
				objFromDb.ISBN = product.ISBN;
				objFromDb.Price = product.Price;
				objFromDb.Price50 = product.Price50;
				objFromDb.ListPrice = product.ListPrice;
				objFromDb.Price100 = product.Price100;
				objFromDb.Description = product.Description;
				objFromDb.CategoryId = product.CategoryId;
				objFromDb.Author = product.Author;
				if (product.ImageUrl != null)
				{
					objFromDb.ImageUrl = product.ImageUrl;
				}
			}
		}
    }
}
