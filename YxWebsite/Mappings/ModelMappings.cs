
using YxWebsite.Models;
using YxWebsite.Dtos;

namespace YxWebsite.Mappings
{
    public class ModelMappings : AutoMapper.Profile
    {
        public ModelMappings() 
        {
            // Language Cottage
            CreateMap<LcModel, LcDto>().ReverseMap();

            // Audit Trails
            CreateMap<AuditTrailsModel, AuditTrailsDto>().ReverseMap();
        }
    }
}
