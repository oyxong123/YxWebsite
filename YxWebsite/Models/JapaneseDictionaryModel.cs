namespace YxWebsite.Models
{
    public class JapaneseDictionaryModel
    {
        // Class constructor.
        public JapaneseDictionaryModel
            (
            string phrase,
            string pKatakana,
            string pHiragana,
            string romaji,
            string meaning
            ) 
        { 
            Phrase = phrase;
            PronunciationKatakana = pKatakana;
            PronunciationHiragana = pHiragana;
            Romaji = romaji;
            Meaning = meaning;
        }

        public JapaneseDictionaryModel() { }

        public int Id { get; set; }
        public required string Phrase { get; set; }
        public required string PronunciationKatakana { get; set; }
        public required string PronunciationHiragana { get; set; }
        public required string Romaji { get; set; }
        public required string Meaning { get; set; }
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
    }
}
