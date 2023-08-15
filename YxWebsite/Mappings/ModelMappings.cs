
using YxWebsite.Models;
using YxWebsite.Dtos;

namespace YxWebsite.Mappings
{
    public class ModelMappings : AutoMapper.Profile
    {
        public ModelMappings() 
        {
            // LanguageCottage
            CreateMap<LanguageCottageModel, LcDto>().ReverseMap();
        }
    }
}
