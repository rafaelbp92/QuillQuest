using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuillQuestWeb.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
		[DisplayName("Category Name")]
		public required string Name { get; set; }
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
