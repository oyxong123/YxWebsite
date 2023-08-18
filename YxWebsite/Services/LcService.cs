using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> UploadLcRecord(LcDto newLcDto)
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("The LanguageCottage db is not initialized.");
                    }

                    LanguageCottageModel? previousRecord = await _context.DbLanguageCottage.OrderByDescending(lc => lc.RecordId).FirstOrDefaultAsync();
                    if (previousRecord  == null) 
                    {
                        newLcDto.RecordId = 1;
                    }
                    else
                    {
                        newLcDto.RecordId = previousRecord.RecordId++;
                    }

                    LanguageCottageModel _lcModel = _mapper.Map<LanguageCottageModel>(newLcDto);
                    await _context.DbLanguageCottage.AddAsync(_lcModel);
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

        public async Task<List<LcDto>> GetAllLcRecord()
        {
            List<LcDto> lcDtoList = new();

            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("The LanguageCottage db is not initialized.");
                    }

                    List<LanguageCottageModel> lcList = await _context.DbLanguageCottage.ToListAsync();
                    foreach (LanguageCottageModel lc in lcList)
                    {
                        LcDto _lcModel = _mapper.Map<LcDto>(lc);
                        lcDtoList.Add(_lcModel);
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return lcDtoList;
        }
    }
}
