using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YxWebsite.Models
{
    public class LcModel
    {
        [Key]
        public int Id { get; set; }
        public int RecordId { get; set; }
        public required string Romaji { get; set; }
        public required string OriginalText { get; set; }
        public required string EnglishTranslation { get; set; }
        public string? Commentary { get; set; }
        public required byte[] Image { get; set; }
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
        public required int LcCategoryId { get; set; }
        [ForeignKey("LcCategoryId")]
        public LcCategoryModel? LcCategory { get; set; }
    }
}
