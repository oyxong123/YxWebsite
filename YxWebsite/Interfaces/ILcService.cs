using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcService
    {
        Task<LcDto> UploadLcRecord(LcDto newLc);
        Task<bool> EditLcRecord(LcDto modifiedLc, int lcId);
        Task<bool> DeleteLcRecord(LcDto deletingLc);
        Task<List<LcDto>> GetAllLcRecordByLcCategory(int lcCategoryId);
        Task<LcDto> GetLcRecordById(int lcId);
    }
}
