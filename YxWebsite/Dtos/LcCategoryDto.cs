using System.Diagnostics.CodeAnalysis;

namespace YxWebsite.Dtos
{
    public class LcCategoryDto
    {
        [SetsRequiredMembers]
        public LcCategoryDto() { }

        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required byte[] Image { get; set; } = Array.Empty<byte>();
        public required DateTime AddedDateTime { get; set; } = DateTime.UtcNow;
        public required DateTime LastModifiedDateTime { get; set; }
        public LcCategoryDto ShallowCopy()
        {
            return (LcCategoryDto)this.MemberwiseClone();
        }

        // Not mapped
        public string? ImageUrl { get; set; }
    }
}
