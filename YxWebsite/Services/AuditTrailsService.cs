using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YxWebsite.Context;
using YxWebsite.Dtos;
using YxWebsite.Interfaces;
using YxWebsite.Models;

namespace YxWebsite.Services
{
    public class AuditTrailsService : IAuditTrailsService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IMapper _mapper;

        public AuditTrailsService(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task AddAuditTrail(AuditTrailsDto auditTrailDto)
        {
            try
            {
                using (ApplicationDbContext _context = _contextFactory.CreateDbContext())
                {
                    if (_context.DbAuditTrails == null)
                    {
                        throw new Exception("DbAuditTrails is not initialized");
                    }

                    AuditTrailsModel auditTrailsModel = _mapper.Map<AuditTrailsModel>(auditTrailDto);
                    await _context.DbAuditTrails.AddAsync(auditTrailsModel);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
