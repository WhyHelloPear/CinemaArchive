using AutoMapper;
using Core.Application.DTOs;
using UI.ViewModels;

public class UIMapper : Profile
{
    public UIMapper()
    {
        CreateMap<FilmDto, FilmViewModel>()
            .ForMember(vm => vm.FilmId, m => m.MapFrom(dto => dto.FilmId))
            .ForMember(vm => vm.FilmTitle, m => m.MapFrom(dto => dto.FilmTitle))
            .ForMember(vm => vm.ReleaseDate, m => m.MapFrom(dto => dto.ReleaseDate))
        ;

        CreateMap<FilmViewModel, FilmDto>();
    }
}
