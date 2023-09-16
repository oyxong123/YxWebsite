using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface IAuditTrailsService
    {
        Task<bool> AddAuditTrail(AuditTrailsDto auditTrailDto);
    }
}
