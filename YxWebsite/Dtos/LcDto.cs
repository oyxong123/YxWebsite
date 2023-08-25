using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YxWebsite.Dtos
{
    public class LcDto
    {
        public LcDto() { }

        public int Id { get; set; }
        public int RecordId { get; set; }
        public required string Romaji { get; set; }
        public required string OriginalText { get; set; }
        public required string EnglishTranslation { get; set; }
        public string? Commentary { get; set; }
        public required byte[] Image { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
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
