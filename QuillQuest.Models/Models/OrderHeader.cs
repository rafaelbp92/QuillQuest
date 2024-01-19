using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuillQuest.Models.Models
{
    public class OrderHeader
    {
        public Guid Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double OrderTotal { get; set; }

        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateOnly PaymentDueDate { get; set; }

        public string? PaymentIntentId { get; set; }

        public required string Name { get; set; }
        [DisplayName("Street Address")]
        public required string StreetAddress { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        [DisplayName("Postal Code")]
        public required string PostalCode { get; set; }
        [DisplayName("Phone Number")]
        public required string PhoneNumber { get; set; }
    }
}
