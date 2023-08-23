﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YxWebsite.Models
{
    public class LanguageCottageModel
    {
        [Key]
        public int Id { get; set; }
        public decimal RecordId { get; set; }
        public required string Romaji { get; set; }
        public required string OriginalText { get; set; }
        public required string EnglishTranslation { get; set; }
        public string? Commentary { get; set; }
        public required byte[] Image { get; set; }
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
    }
}
