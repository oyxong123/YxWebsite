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
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
        private readonly IMapper _mapper;

        public LcService(IDbContextFactory<ApplicationDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<LcDto> UploadLcRecord(LcDto newLcDto)
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
                    if (newLcDto.RecordId == 0)
                    {
                        LcDto? previousRecordDto = _mapper.Map<LcDto>(await _context.DbLanguageCottage.OrderByDescending(lc => lc.RecordId).FirstOrDefaultAsync());
                        if (previousRecordDto == null)
                        {
                            newLcDto.RecordId = 1;
                        }
                        else
                        {
                            newLcDto.RecordId = ++previousRecordDto.RecordId;
                        }
                    }
                    else
                    {
                        // Insert the new record to a previous Record ID location and increment/decrement other records by 1 to fill in its previous location.
                        if (await _context.DbLanguageCottage.AnyAsync(lc => lc.RecordId == newLcDto.RecordId))
                        {
                            // Increment all record ID larger than the specified record ID by 1.
                            List<LcModel> lcModelList = await _context.DbLanguageCottage.Where(lc => lc.RecordId >= newLcDto.RecordId).ToListAsync();
                            foreach (LcModel lc in lcModelList)
                            {
                                lc.RecordId++;
                                _context.Entry(lc).State = EntityState.Modified;
                            }
                        }
                    }
                    
                    LcModel _lcModel = _mapper.Map<LcModel>(newLcDto);
                    await _context.DbLanguageCottage.AddAsync(_lcModel);
                    await _context.SaveChangesAsync();

                    // Add audit trail model and call.
                }

                return newLcDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> EditLcRecord(LcDto editLcDto, int lcId)
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
                    if (editLcDto.RecordId == 0)
                    {
                        LcDto? previousRecordDto = _mapper.Map<LcDto>(await _context.DbLanguageCottage.OrderByDescending(lc => lc.RecordId).FirstOrDefaultAsync());
                        if (previousRecordDto == null)
                        {
                            editLcDto.RecordId = 1;
                        }
                        else
                        {
                            editLcDto.RecordId = ++previousRecordDto.RecordId;
                        }
                    }
                    else
                    {
                        // Insert the new record to a previous Record ID location and increment/decrement other records by 1 to fill in its previous location.
                        if (await _context.DbLanguageCottage.AnyAsync(lc => lc.RecordId == editLcDto.RecordId))
                        {
                            int oldRecordId = await _context.DbLanguageCottage.Where(lc => lc.Id == lcId).Select(lc => lc.RecordId).SingleOrDefaultAsync();
                            if (editLcDto.RecordId < oldRecordId)
                            {
                                // Increment all record ID equal or larger than the specified record ID and smaller than the old RecordID by 1.
                                await _context.DbLanguageCottage.Where(lc => lc.RecordId >= editLcDto.RecordId && lc.RecordId < oldRecordId).ExecuteUpdateAsync(lc => lc.SetProperty(u => u.RecordId, u => u.RecordId + 1));
                            }
                            else if (editLcDto.RecordId > oldRecordId)
                            {
                                // Decrement all record ID equal or lesser than the specified record ID and larger than the old RecordID by 1.
                                await _context.DbLanguageCottage.Where(lc => lc.RecordId <= editLcDto.RecordId && lc.RecordId > oldRecordId).ExecuteUpdateAsync(lc => lc.SetProperty(u => u.RecordId, u => u.RecordId - 1));
                            }
                        }
                    }

                    LcModel _lcModel = _mapper.Map<LcModel>(editLcDto);
                    _context.Entry(_lcModel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    // Add audit trail model and call.
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteLcRecord(LcDto deleteLcDto)
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
                    await _context.DbLanguageCottage.Where(lc => lc.RecordId > deleteLcDto.RecordId).ExecuteUpdateAsync(lc => lc.SetProperty(u => u.RecordId, u => u.RecordId - 1));

                    LcModel _lcModel = _mapper.Map<LcModel>(deleteLcDto);
                    _context.Remove(_lcModel);
                    await _context.SaveChangesAsync();

                    // Add audit trail model and call.

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<LcDto>> GetAllLcRecord()
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
                    List<LcModel> _lcList = await _context.DbLanguageCottage.OrderBy(lc => lc.RecordId).ToListAsync();
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

                    LcModel? _lcModel = await _context.DbLanguageCottage.SingleOrDefaultAsync(lc => lc.Id == lcId);
                    if (_lcModel == null)
                    {
                        throw new Exception("Lc record not found.");
                    }
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
