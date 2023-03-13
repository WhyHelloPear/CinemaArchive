using AutoMapper;
using Core.Application.DTOs;
using UI.ViewModels;

public class UIMapper : Profile
{
    public UIMapper()
    {
        CreateMap<FilmDto, FilmViewModel>();
        CreateMap<FilmViewModel, FilmDto>();
    }
}
