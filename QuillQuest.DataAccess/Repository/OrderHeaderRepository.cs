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
    public class OrderheaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
    {
        private readonly QuillQuestDbContext _dbContext;


        public OrderheaderRepository(QuillQuestDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public void Update(OrderHeader orderHeader)
        {
            _dbContext.OrderHeaders.Update(orderHeader);
        }

        public void UpdateStatus(Guid id, OrderStatusEnum orderStatus, PaymentStatusEnum? paymentStatus = null)
        {
            var orderHeaderDb = _dbContext.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderHeaderDb != null)
            {
                orderHeaderDb.OrderStatus = orderStatus;
                if(paymentStatus != null)
                {
                    orderHeaderDb.PaymentStatus = paymentStatus;
                }
            }
        }

        public void UpdateStripePaymentId(Guid id, string sessionId, string paymentIntentId)
        {
            var orderHeaderDb = _dbContext.OrderHeaders.FirstOrDefault(x => x.Id == id);
            if (orderHeaderDb != null)
            {
                if (!string.IsNullOrEmpty(sessionId))
                {
                    orderHeaderDb.SessionId = sessionId;
                }
                if (!string.IsNullOrEmpty(paymentIntentId))
                {
                    orderHeaderDb.SessionId = paymentIntentId;
                    orderHeaderDb.PaymentDate = DateTime.Now;
                }
            }
        }
    }
}
