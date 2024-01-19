using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
using QuillQuest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.DataAccess.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly QuillQuestDbContext _dbContext;

        public OrderDetailRepository(QuillQuestDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public void Update(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Update(orderDetail);
        }
    }
}
