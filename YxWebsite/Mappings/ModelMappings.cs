
using YxWebsite.Models;
using YxWebsite.Dtos;

namespace YxWebsite.Mappings
{
    public class ModelMappings : AutoMapper.Profile
    {
        public ModelMappings()
        {
            // Audit Trails
            CreateMap<AuditTrailsModel, AuditTrailsDto>().ReverseMap();

            // Language Cottage
            CreateMap<LcModel, LcDto>().ReverseMap();

            // Language Cottage Category
            CreateMap<LcCategoryModel, LcCategoryDto>().ReverseMap();

            // Login
            CreateMap<LoginModel, LoginDto>().ReverseMap();
        }
    }
}
