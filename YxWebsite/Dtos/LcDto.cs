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
        public DateTime AddedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public required int LcCategoryId { get; set; }
        [ForeignKey("LcCategoryId")]
        public LcCategoryModel? LcCategory { get; set; }
        public LcDto ShallowCopy()
        {
            return (LcDto)this.MemberwiseClone();
        }

        [NotMapped]
        public string? ImageUrl { get; set; }

        [NotMapped]
        public string RecordIdString { get; set; } = string.Empty;
    }
}
