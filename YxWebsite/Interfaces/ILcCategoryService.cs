using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcCategoryService
    {
        Task<LcCategoryDto> UploadLcCategoryRecord(LcCategoryDto newLcCategory);
        Task<bool> EditLcCategoryRecord(LcCategoryDto modifiedLcCategory);
        Task<bool> DeleteLcCategoryRecord(LcCategoryDto deletingLcCategory);
        Task<List<LcCategoryDto>> GetAllLcCategories();
        Task<LcCategoryDto> GetLcCategoryRecordById(int lcCategoryId);
    }
}
