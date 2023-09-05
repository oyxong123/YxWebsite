using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface IAuditTrailsService
    {
        Task AddAuditTrail(AuditTrailsDto auditTrailDto);
    }
}
