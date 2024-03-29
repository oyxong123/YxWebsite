﻿using System.ComponentModel.DataAnnotations;

namespace YxWebsite.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Salt { get; set; }
        public bool IsAdmin { get; set; }
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
    }
}
