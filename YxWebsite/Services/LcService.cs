using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YxWebsite.Context;
using YxWebsite.Dtos;
using YxWebsite.Interfaces;
using YxWebsite.Models;

namespace YxWebsite.Services
{
    public class LcService : ILcService
    {
        private readonly IAuditTrailsService _auditTrailsService;
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IMapper _mapper;

        public LcService(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper, IAuditTrailsService auditTrailsService)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _auditTrailsService = auditTrailsService;
        }

        public async Task<LcDto> UploadLcRecord(LcDto newLc)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("DbLanguageCottage is not initialized.");
                    }

                    // Set latest LC's record ID as plus one of the previous record if no record ID is specified.
                    if (newLc.RecordId == 0)
                    {
                        LcDto? previousRecordDto = _mapper.Map<LcDto>(await _context.DbLanguageCottage.OrderByDescending(lc => lc.RecordId).FirstOrDefaultAsync());
                        if (previousRecordDto == null)
                        {
                            newLc.RecordId = 1;
                        }
                        else
                        {
                            newLc.RecordId = ++previousRecordDto.RecordId;
                        }
                    }
                    else
                    {
                        // Insert the new record to a previous Record ID location and increment/decrement other records by 1 to fill in its previous location.
                        if (await _context.DbLanguageCottage.AnyAsync(lc => lc.RecordId == newLc.RecordId))
                        {
                            // Increment all record ID larger than the specified record ID by 1.
                            await _context.DbLanguageCottage.Where(lc => lc.RecordId >= newLc.RecordId).ExecuteUpdateAsync(lc => lc.SetProperty(u => u.RecordId, u => u.RecordId + 1));
                        }
                    }
                    
                    LcModel _addingLcModel = _mapper.Map<LcModel>(newLc);
                    _context.Entry(_addingLcModel).State = EntityState.Added;
                    await _context.SaveChangesAsync();

                    AuditTrailsDto _auditTrailsDto = new()
                    {
                        Description = "Inserted LC Record at Record ID #" + newLc.RecordId,
                        AddedDateTime = DateTime.UtcNow
                    };
                    await _auditTrailsService.AddAuditTrail(_auditTrailsDto);
                }

                return newLc;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> EditLcRecord(LcDto modifiedLc, int lcId)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("DbLanguageCottage is not initialized.");
                    }

                    // Set latest LC's record ID as plus one of the previous record if no record ID is specified.
                    if (modifiedLc.RecordId == 0)
                    {
                        LcDto? previousRecordDto = _mapper.Map<LcDto>(await _context.DbLanguageCottage.OrderByDescending(lc => lc.RecordId).FirstOrDefaultAsync());
                        if (previousRecordDto == null)
                        {
                            modifiedLc.RecordId = 1;
                        }
                        else
                        {
                            modifiedLc.RecordId = ++previousRecordDto.RecordId;
                        }
                    }
                    else
                    {
                        // Insert the new record to a previous Record ID location and increment/decrement other records by 1 to fill in its previous location.
                        if (await _context.DbLanguageCottage.AnyAsync(lc => lc.RecordId == modifiedLc.RecordId))
                        {
                            int oldRecordId = await _context.DbLanguageCottage.Where(lc => lc.Id == lcId).Select(lc => lc.RecordId).SingleOrDefaultAsync();
                            if (modifiedLc.RecordId < oldRecordId)
                            {
                                // Increment all record ID equal or larger than the specified record ID and smaller than the old RecordID by 1.
                                await _context.DbLanguageCottage.Where(lc => lc.RecordId >= modifiedLc.RecordId && lc.RecordId < oldRecordId).ExecuteUpdateAsync(lc => lc.SetProperty(u => u.RecordId, u => u.RecordId + 1));
                            }
                            else if (modifiedLc.RecordId > oldRecordId)
                            {
                                // Decrement all record ID equal or lesser than the specified record ID and larger than the old RecordID by 1.
                                await _context.DbLanguageCottage.Where(lc => lc.RecordId <= modifiedLc.RecordId && lc.RecordId > oldRecordId).ExecuteUpdateAsync(lc => lc.SetProperty(u => u.RecordId, u => u.RecordId - 1));
                            }
                        }
                    }

                    LcModel _modifyingLcModel = _mapper.Map<LcModel>(modifiedLc);
                    _context.Entry(_modifyingLcModel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    AuditTrailsDto _auditTrailsDto = new()
                    {
                        Description = "Inserted LC Record at Record ID #" + modifiedLc.RecordId,
                        AddedDateTime = DateTime.UtcNow
                    };
                    await _auditTrailsService.AddAuditTrail(_auditTrailsDto);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteLcRecord(LcDto deletingLc)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("DbLanguageCottage is not initialized.");
                    }

                    // Decrement all record ID larger than the deleting record's record ID.
                    await _context.DbLanguageCottage.Where(lc => lc.RecordId > deletingLc.RecordId).ExecuteUpdateAsync(lc => lc.SetProperty(u => u.RecordId, u => u.RecordId - 1));

                    LcModel _deletingLcModel = _mapper.Map<LcModel>(deletingLc);
                    _context.Entry(_deletingLcModel).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();

                    AuditTrailsDto _auditTrailsDto = new()
                    {
                        Description = "Inserted LC Record at Record ID #" + deletingLc.RecordId,
                        AddedDateTime = DateTime.UtcNow
                    };
                    await _auditTrailsService.AddAuditTrail(_auditTrailsDto);

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<LcDto>> GetAllLcRecordByLcCategory(int lcCategoryId)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("DbLanguageCottage is not initialized.");
                    }

                    List<LcDto> lcDtoList = new();
                    List<LcModel> _lcList = await _context.DbLanguageCottage.Where(u => u.LcCategoryId == lcCategoryId).OrderBy(lc => lc.RecordId).ToListAsync();
                    foreach (LcModel _lc in _lcList)
                    {
                        LcDto _lcModel = _mapper.Map<LcDto>(_lc);
                        lcDtoList.Add(_lcModel);
                    }

                    return lcDtoList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<LcDto> GetLcRecordById(int lcId)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("DbLanguageCottage is not initialized.");
                    }

                    LcModel? _lcModel = await _context.DbLanguageCottage.SingleOrDefaultAsync(lc => lc.Id == lcId) ?? throw new Exception("Lc record not found.");
                    LcDto lcDto = _mapper.Map<LcDto>(_lcModel);

                    return lcDto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
