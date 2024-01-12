using System.ComponentModel.DataAnnotations;

namespace QuillQuestWeb.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
