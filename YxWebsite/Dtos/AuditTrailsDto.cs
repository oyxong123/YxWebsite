namespace YxWebsite.Dtos
{
    public class AuditTrailsDto
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public DateTime AddedDateTime { get; set; }
    }
}
