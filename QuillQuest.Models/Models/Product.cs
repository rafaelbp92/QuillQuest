using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuillQuest.Models.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; }
        public required string ISBN { get; set; }
        public required string Author { get; set; }

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
		public Category Category { get; set; }
		[DisplayName("List Price")]
        [Range(1, 1000)]
        public required double ListPrice { get; set; }

        [DisplayName("Price for 1- 50")]
        [Range(1, 1000)]
        public required double Price { get; set; }

        [DisplayName("Price for 50+")]
        [Range(1, 1000)]
        public required double Price50 { get; set; }

        [DisplayName("Price for 100+")]
        [Range(1, 1000)]
        public required double Price100 { get; set; }
        public string ImageUrl { get; set; }

    }
}
