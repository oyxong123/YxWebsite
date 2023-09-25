namespace YxWebsite.Dtos
{
    public class LcCategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Category { get; set; }  
        public string Description { get; set; } = string.Empty;
        public required DateTime AddedDateTime { get; set; }
        public required DateTime LastModifiedDateTime { get; set; }
    }
}
