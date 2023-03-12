using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        CreateMap<FilmDto, Film>();
        CreateMap<Film, FilmDto>();
    }
}
