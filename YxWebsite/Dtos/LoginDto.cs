namespace YxWebsite.Dtos
{
    public class LoginDto
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Hash { get; set; }
        public int IsAdmin { get; set; }
    }
}
