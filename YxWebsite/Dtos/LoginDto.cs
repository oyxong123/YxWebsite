using System.Diagnostics.CodeAnalysis;

namespace YxWebsite.Dtos
{
    public class LoginDto
    {
        [SetsRequiredMembers]
        public LoginDto() { }

        public int Id { get; set; }
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string Hash { get; set; } = string.Empty;
        public int IsAdmin { get; set; }
    }
}
