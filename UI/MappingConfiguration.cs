using AutoMapper;
using Core.Application.DTOs;
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
    }
}
