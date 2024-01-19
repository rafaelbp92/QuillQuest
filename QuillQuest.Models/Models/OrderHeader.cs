using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using QuillQuest.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        public OrderStatusEnum? OrderStatus { get; set; }
        public PaymentStatusEnum? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateOnly PaymentDueDate { get; set; }
        public string? SessionId {  get; set; }
        public string? PaymentIntentId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

    }
}
