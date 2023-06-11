namespace MyPersonalWebsite.Models
{
    public class LanguageCottage
    {
        public int Id { get; set; }
        public string? Romaji { get; set; }
        public string? OriginalText { get; set; }
        public string? EnglishTranslation { get; set; }
        public byte[]? Image { get; set; }
        public DateTime AddedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
