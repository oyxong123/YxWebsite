namespace MyPersonalWebsite.Models
{
    public class JapaneseDictionary
    {
        public int Id { get; set; }
        public string? Phrase { get; set; }
        public string? PronunciationKatakana { get; set; }
        public string? PronunciationHiragana { get; set; }
        public string? Romaji { get; set; }
        public string? Meaning { get; set; }
    }
}
