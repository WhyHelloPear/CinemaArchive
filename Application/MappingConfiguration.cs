using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<FilmDto, Film>()
            .ReverseMap();

        CreateMap<GenreDto, Genre>()
            .ReverseMap();

        CreateMap<PersonDto, Person>()
            .ReverseMap();

        CreateMap<FilmRoleDto, FilmRole>()
            .ReverseMap();
    }
}
