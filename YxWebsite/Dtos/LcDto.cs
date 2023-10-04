using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using YxWebsite.Models;

namespace YxWebsite.Dtos
{
    public class LcDto
    {
        [SetsRequiredMembers]
        public LcDto() { }

        public int Id { get; set; }
        public int RecordId { get; set; }
        public required string Romaji { get; set; } = string.Empty;
        public required string OriginalText { get; set; } = string.Empty;
        public required string EnglishTranslation { get; set; } = string.Empty;
        public string? Commentary { get; set; }
        public required byte[] Image { get; set; } = Array.Empty<byte>();
        public required DateTime AddedDateTime { get; set; } = DateTime.UtcNow;
        public required DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;
        public required int LcCategoryId { get; set; }
        [ForeignKey("LcCategoryId")]
        public LcCategoryModel? LcCategory { get; set; }
        public LcDto ShallowCopy()
        {
            return (LcDto)this.MemberwiseClone();
        }

        // Not mapped
        public string? ImageUrl { get; set; }
        public string RecordIdString { get; set; } = string.Empty;
    }
}
