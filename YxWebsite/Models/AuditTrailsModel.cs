using System.ComponentModel.DataAnnotations;

namespace YxWebsite.Models
{
    public class AuditTrailsModel
    {
        [Key]
        public int Id { get; set; }
        public required string Description { get; set; }
        public required DateTime AddedDateTime { get; set; }
    }
}
