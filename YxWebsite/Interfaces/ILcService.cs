using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcService
    {
        Task<LcDto> UploadLcRecord(LcDto lcDto);
        Task<bool> EditLcRecord(LcDto lcDto, int lcId);
        Task<bool> DeleteLcRecord(LcDto deleteLcDto);
        Task<List<LcDto>> GetAllLcRecordByLcCategory(int lcCategoryId);
        Task<LcDto> GetLcRecordById(int lcId);
    }
}
