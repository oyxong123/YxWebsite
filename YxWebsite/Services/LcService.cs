﻿using AutoMapper;
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

                    // Set latest LC's record ID as plus one of the previous record.
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
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottage == null)
                    {
                        throw new Exception("The LanguageCottage db is not initialized.");
                    }

                    List<LcDto> lcDtoList = new();
                    List<LanguageCottageModel> _lcList = await _context.DbLanguageCottage.OrderByDescending(lc => lc.Id).ToListAsync();
                    foreach (LanguageCottageModel _lc in _lcList)
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
                        throw new Exception("The LanguageCottage db is not initialized.");
                    }

                    LanguageCottageModel? _lcModel = await _context.DbLanguageCottage.SingleOrDefaultAsync(lc => lc.Id == lcId);
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
