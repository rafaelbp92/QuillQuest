using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuillQuest.Models.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
		[DisplayName("Category Name")]
        [MaxLength(30)]
		public required string Name { get; set; }
        [DisplayName("Display Order")]
        [Required]
        [Range(1, 100, ErrorMessage = "Display order must be between 1 and 100")]
        public int? DisplayOrder { get; set; }
    }
}
