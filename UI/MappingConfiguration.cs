using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;
using UI.ViewModels;

public class UIMapper : Profile
{
    public UIMapper()
    {
        CreateMap<FilmDto, FilmViewModel>()
            .ReverseMap();

        CreateMap<GenreDto, GenreViewModel>()
            .ReverseMap();

        CreateMap<PersonDto, PersonViewModel>()
            .ReverseMap();

        CreateMap<FilmRoleDto, FilmRoleViewModel>()
            .ReverseMap();
    }
}
