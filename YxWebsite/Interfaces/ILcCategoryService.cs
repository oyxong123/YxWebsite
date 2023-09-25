using YxWebsite.Dtos;

namespace YxWebsite.Interfaces
{
    public interface ILcCategoryService
    {
        Task<IEnumerable<LcCategoryDto>> GetAllLcCategories();
    }
}
