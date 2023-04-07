using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;
using Infrastructure.DataAccess.Entities;
using UI.ViewModels;

public class UIMappingConfig : Profile
{
    public UIMappingConfig()
    {
        CreateMap<FilmDto, FilmViewModel>()
            .ReverseMap();

        CreateMap<GenreDto, GenreViewModel>()
            .ReverseMap();

        CreateMap<PersonDto, PersonViewModel>()
            .ReverseMap();

        CreateMap<FilmRoleDto, FilmRoleViewModel>()
            .ReverseMap();

        CreateMap<FilmPersonLinkDto, FilmPersonLinkViewModel>()
            .ForMember( vm => vm.FilmRoleId, m => m.MapFrom( dto => dto.FilmRole.FilmRoleId ) )
            .ForMember( vm => vm.PersonId, m => m.MapFrom( dto => dto.Person.PersonId ) )
            .ForMember( vm => vm.FilmPersonLinkId, m => m.MapFrom( dto => dto.FilmPersonLinkId ) )
            .ForMember( vm => vm.PersonFirstName, m => m.MapFrom( dto => dto.Person.FirstName ) )
            .ForMember( vm => vm.FilmRoleName, m => m.MapFrom( dto => dto.FilmRole.FilmRoleName ) )
            .ForMember( vm => vm.PersonLastName, m => m.MapFrom( dto => dto.Person.LastName ) );
    }
}
