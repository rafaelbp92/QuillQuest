﻿using QuillQuest.DataAccess.Data;
using QuillQuest.DataAccess.Repository.Interface;
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
    }
}
