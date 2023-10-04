using System.ComponentModel.DataAnnotations;

namespace YxWebsite.Models
{
    public class LcCategoryModel
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }  // Indicates it is a Game/Book/Article etc.
        public string Description { get; set; } = string.Empty;
        public required byte[] Image { get; set; }
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
    }
}
