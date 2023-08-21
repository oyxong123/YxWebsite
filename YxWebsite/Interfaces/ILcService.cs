using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcService
    {
        Task<LcDto> UploadLcRecord(LcDto lcDto);
        Task<bool> EditLcRecord(LcDto lcDto, int lcId);
        Task<List<LcDto>> GetAllLcRecord();
        Task<LcDto> GetLcRecordById(int lcId);
    }
}
