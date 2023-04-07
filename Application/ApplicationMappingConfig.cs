using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;
using Infrastructure.DataAccess.Entities;

public class ApplicationMappingConfig : Profile
{
    public ApplicationMappingConfig()
    {
        CreateMap<FilmDto, Film>()
            .ReverseMap();

        CreateMap<GenreDto, Genre>()
            .ReverseMap();

        CreateMap<PersonDto, Person>()
            .ReverseMap();

        CreateMap<FilmRoleDto, FilmRole>()
            .ReverseMap();

        CreateMap<FilmPersonLink, FilmPersonLinkDto>()
            .ForMember( f => f.Film, m => m.MapFrom( fe => fe.RelatedFilm ) )
            .ForMember( f => f.Person, m => m.MapFrom( fe => fe.RelatedPerson ) )
            .ForMember( f => f.FilmRole, m => m.MapFrom( fe => fe.RelatedFilmRole ) )
            .ReverseMap();
    }
}
