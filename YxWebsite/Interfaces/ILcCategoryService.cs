using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcCategoryService
    {
        Task<List<LcCategoryDto>> GetAllLcCategories();
        Task<LcCategoryDto> UploadLcCategoryRecord(LcCategoryDto newLcCategory);
        Task<bool> EditLcCategoryRecord(LcCategoryDto modifiedLcCategory, int lcCategoryId);
        Task<bool> DeleteLcCategoryRecord(LcCategoryDto deletingLcCategory);
    }
}
