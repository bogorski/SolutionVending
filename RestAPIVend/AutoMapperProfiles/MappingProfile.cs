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

            CreateMap<Faktury, FakturyForView>();
            CreateMap<FakturyForView, Faktury>();

            CreateMap<Lokalizacje, LokalizacjeForView>();
            CreateMap<LokalizacjeForView, Lokalizacje>();

            CreateMap<Magazyny, MagazynyForView>();
            CreateMap<MagazynyForView, Magazyny>();

            CreateMap<StanowiskaPracy, StanowiskaPracyForView>();
            CreateMap<StanowiskaPracyForView, StanowiskaPracy>();

            CreateMap<Towary, TowaryForView>();
            CreateMap<TowaryForView, Towary>();

            CreateMap<Trasy, TrasyForView>();
            CreateMap<TrasyForView, Trasy>();

            CreateMap<Warsztaty, WarsztatyForView>();
            CreateMap<WarsztatyForView, Warsztaty>();
            
            CreateMap<Pojazdy, PojazdyForView>()
                .ForMember(dest => dest.WarsztatData,
                    opt => opt.MapFrom(src => src.IdwarsztatuNavigation != null ? src.IdwarsztatuNavigation.Nazwa : null));
            CreateMap<PojazdyForView, Pojazdy>()
                .ForMember(dest => dest.IdwarsztatuNavigation, opt => opt.Ignore());
        }
    }
}