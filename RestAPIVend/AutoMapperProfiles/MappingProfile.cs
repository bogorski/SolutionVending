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

            CreateMap<Pracownicy, PracownicyForView>()
                .ForMember(dest => dest.StanowiskoPracyData,
                    opt => opt.MapFrom(src => src.IdstanowiskaPracyNavigation != null ? src.IdstanowiskaPracyNavigation.NazwaStanowiska : null))
                .ForMember(dest => dest.PojazdData,
                opt => opt.MapFrom(src => src.IdpojazduNavigation != null ? src.IdpojazduNavigation.NumerRejestracyjny : null))
                .ForMember(dest => dest.TrasaData,
                    opt => opt.MapFrom(src => src.IdtrasyNavigation != null ? src.IdtrasyNavigation.Nazwa : null));
            CreateMap<PracownicyForView, Pracownicy>()
                .ForMember(dest => dest.IdstanowiskaPracyNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdpojazduNavigation, opt => opt.Ignore())
                .ForMember(dest => dest.IdtrasyNavigation, opt => opt.Ignore());
        }
    }
}