using QuillQuest.Models.Enums;
using QuillQuest.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.DataAccess.Repository.Interface
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        void Update(OrderHeader orderHeader);
        void UpdateStatus(Guid id, OrderStatusEnum orderStatus, PaymentStatusEnum? paymentStatus = null);
        void UpdateStripePaymentId(Guid id, string sessionId, string paymentIntentId);
    }
}
