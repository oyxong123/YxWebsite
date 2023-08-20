﻿using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcService
    {
        Task<bool> UploadLcRecord(LcDto lcDto);
        Task<bool> EditLcRecord(LcDto lcDto);
        Task<List<LcDto>> GetAllLcRecord();
        Task<LcDto> GetLcRecordById(int lcId);
    }
}
