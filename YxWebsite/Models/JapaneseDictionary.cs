namespace MyPersonalWebsite.Models
{
    public class JapaneseDictionary
    {
        // Class constructor.
        public JapaneseDictionary
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

        public JapaneseDictionary() { }

        public int Id { get; set; }
        public required string Phrase { get; set; }
        public required string PronunciationKatakana { get; set; }
        public required string PronunciationHiragana { get; set; }
        public required string Romaji { get; set; }
        public required string Meaning { get; set; }
    }
}
