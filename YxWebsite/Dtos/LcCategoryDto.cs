using System.Diagnostics.CodeAnalysis;

namespace YxWebsite.Dtos
{
    public class LcCategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required DateTime AddedDateTime { get; set; } = DateTime.UtcNow;
        public required DateTime LastModifiedDateTime { get; set; }

        [SetsRequiredMembers]
        public LcCategoryDto() { } 
    }
}
