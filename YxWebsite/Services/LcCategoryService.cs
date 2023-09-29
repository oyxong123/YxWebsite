﻿using AutoMapper;
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

        public async Task<IEnumerable<LcCategoryDto>> GetAllLcCategories()
        {
            try
            {
                using (ApplicationDbContext _context = await _contextFactory.CreateDbContextAsync())
                {
                    if (_context.DbLanguageCottageCategory == null)
                    {
                        throw new Exception("LC Category" + __tableNotInitialized);
                    }

                    IEnumerable<LcCategoryModel> lcCategoryModelList = await _context.DbLanguageCottageCategory.ToListAsync();
                    IEnumerable<LcCategoryDto> lcCategoryDtoList = lcCategoryModelList.Select(u => _mapper.Map<LcCategoryDto>(u)).ToList();
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