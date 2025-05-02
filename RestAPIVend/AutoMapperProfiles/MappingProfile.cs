using AutoMapper;
using RestAPIVend.ForView;
using RestAPIVend.Model;

namespace RestAPIVend.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Dostawcy, DostawcyForView>();
            CreateMap<DostawcyForView, Dostawcy>();
        }
    }
}