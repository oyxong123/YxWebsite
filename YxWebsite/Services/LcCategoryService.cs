using AutoMapper;
using Microsoft.EntityFrameworkCore;
using YxWebsite.Context;
using YxWebsite.Dtos;
using YxWebsite.Interfaces;
using YxWebsite.Models;

namespace YxWebsite.Services
{
    public class LcCategoryService : ILcCategoryService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IMapper _mapper;
        private readonly IAuditTrailsService _auditTrailsService;
        private readonly string __tableNotInitialized = " Table is not initialized.";

        public LcCategoryService(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper, IAuditTrailsService auditTrailsService)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
            _auditTrailsService = auditTrailsService;
        }

        public async Task<LcCategoryDto> UploadLcCategoryRecord(LcCategoryDto newLcCategory)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottageCategory == null)
                    {
                        throw new Exception("DbLanguageCottageCategory is not initialized.");
                    }

                    LcCategoryModel _addingLcCategoryModel = _mapper.Map<LcCategoryModel>(newLcCategory);
                    _context.Entry(_addingLcCategoryModel).State = EntityState.Added;
                    await _context.SaveChangesAsync();

                    AuditTrailsDto _auditTrailsDto = new()
                    {
                        Description = "Created LC Category " + newLcCategory.Name,
                        AddedDateTime = DateTime.UtcNow
                    };
                    await _auditTrailsService.AddAuditTrail(_auditTrailsDto);
                }

                return newLcCategory;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> EditLcCategoryRecord(LcCategoryDto modifiedLcCategory, int lcCategoryId)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottageCategory == null)
                    {
                        throw new Exception("DbLanguageCottageCategory is not initialized.");
                    }

                    LcCategoryModel _modifyingLcCategoryModel = _mapper.Map<LcCategoryModel>(modifiedLcCategory);
                    
                    // Set non-modifiable properties.
                    LcCategoryModel _originallcCategoryModel = await _context.DbLanguageCottageCategory.Where(u => u.Id == modifiedLcCategory.Id).SingleAsync();
                    _modifyingLcCategoryModel.AddedDateTime = _originallcCategoryModel.AddedDateTime;

                    _context.Entry(_modifyingLcCategoryModel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    AuditTrailsDto _auditTrailsDto = new()
                    {
                        Description = "Modified details of LC Category " + modifiedLcCategory.Name,
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

        public async Task<bool> DeleteLcCategoryRecord(LcCategoryDto deletingLcCategory)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottageCategory == null)
                    {
                        throw new Exception("DbLanguageCottageCategory is not initialized.");
                    }

                    LcCategoryModel _deletingLcCategoryModel = _mapper.Map<LcCategoryModel>(deletingLcCategory);
                    _context.DbLanguageCottageCategory.Entry(_deletingLcCategoryModel).State = EntityState.Deleted;
                    // Delete all LC records under this deleting LC Category.
                    List<LcModel> _deletingLcModels = await _context.DbLanguageCottage.Where(u => u.LcCategoryId == deletingLcCategory.Id).ToListAsync();
                    _context.Entry(_deletingLcModels).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();

                    AuditTrailsDto _auditTrailsDto = new()
                    {
                        Description = "Deleted LC Category " + deletingLcCategory.Name + " with all of its records",
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

        public async Task<List<LcCategoryDto>> GetAllLcCategories()
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottageCategory == null)
                    {
                        throw new Exception("LC Category" + __tableNotInitialized);
                    }

                    List<LcCategoryModel> lcCategoryModelList = await _context.DbLanguageCottageCategory.ToListAsync();
                    List<LcCategoryDto> lcCategoryDtoList = lcCategoryModelList.Select(_mapper.Map<LcCategoryDto>).ToList();
                    return lcCategoryDtoList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
