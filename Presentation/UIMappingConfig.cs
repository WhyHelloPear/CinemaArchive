using AutoMapper;
using Core.Domain.Models;
using Infrastructure.DataAccess.Entities;
using UI.ViewModels;

public class UIMappingConfig : Profile
{
    public UIMappingConfig()
    {
        CreateMap<Film, FilmViewModel>()
            .ReverseMap();

        CreateMap<Genre, GenreViewModel>()
            .ReverseMap();

        CreateMap<Person, PersonViewModel>()
            .ReverseMap();

        CreateMap<FilmRole, FilmRoleViewModel>()
            .ReverseMap();

        CreateMap<FilmPersonLink, FilmPersonLinkViewModel>()
            .ForMember( vm => vm.FilmRoleId, m => m.MapFrom( dto => dto.RelatedFilmRole.FilmRoleId ) )
            .ForMember( vm => vm.PersonId, m => m.MapFrom( dto => dto.RelatedPerson.PersonId ) )
            .ForMember( vm => vm.FilmPersonLinkId, m => m.MapFrom( dto => dto.FilmPersonLinkId ) )
            .ForMember( vm => vm.PersonFirstName, m => m.MapFrom( dto => dto.RelatedPerson.FirstName ) )
            .ForMember( vm => vm.FilmRoleName, m => m.MapFrom( dto => dto.RelatedFilmRole.FilmRoleName ) )
            .ForMember( vm => vm.PersonLastName, m => m.MapFrom( dto => dto.RelatedPerson.LastName ) );
    }
}
