namespace MyPersonalWebsite.Models
{
    public class LanguageCottage
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateTime { get; set; }
        public string? Romaji { get; set; }
        public string? OriginalText { get; set; }
        public string? EnglishTranslation { get; set; }
        public byte[]? Image { get; set; }
    }
}
