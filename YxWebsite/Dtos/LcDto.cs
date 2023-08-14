using System.ComponentModel.DataAnnotations;

namespace YxWebsite.Dtos
{
    public class LcDto
    {
        public int Id { get; set; }
        public required string Romaji { get; set; }
        public required string OriginalText { get; set; }
        public required string EnglishTranslation { get; set; }
        public required byte[] Image { get; set; }
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
    }
}
