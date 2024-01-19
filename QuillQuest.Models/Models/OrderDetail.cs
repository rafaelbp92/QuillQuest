using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.Models.Models
{
    public class OrderDetail
    {
        public Guid Id { get; set; }
        public required Guid OrderHeaderId { get; set; }
        [ForeignKey("OrderHeaderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        public required Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int Count { get; set; }
        public double Price { get; set; }
    }
}
