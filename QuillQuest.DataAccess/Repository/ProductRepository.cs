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
            _dbContext.Products.Update(product);
        }
    }
}
