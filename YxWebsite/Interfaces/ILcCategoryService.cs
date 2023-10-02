using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcCategoryService
    {
        Task<List<LcCategoryDto>> GetAllLcCategories();
    }
}
