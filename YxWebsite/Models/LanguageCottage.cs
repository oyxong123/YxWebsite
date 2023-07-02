using System.ComponentModel.DataAnnotations;

namespace MyPersonalWebsite.Models
{
    public class LanguageCottage
    {
        // Constructor.
        public LanguageCottage
            (
            string romaji,
            string originalText,
            string englishTranslation,
            byte[] image
            )
        {
            Romaji = romaji;
            OriginalText = originalText;
            EnglishTranslation = englishTranslation;
            Image = image;
            AddedDateTime = DateTime.Now;
            LastModifiedDateTime = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public required string Romaji { get; set; }
        public required string OriginalText { get; set; }
        public required string EnglishTranslation { get; set; }
        public required byte[] Image { get; set; }
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
    }
}
