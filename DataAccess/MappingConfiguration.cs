using AutoMapper;
using Core.Domain.Models;
using Infrastructure.DataAccess.Entities;

public class RepoConfig : Profile
{
    public RepoConfig()
    {
        CreateMap<FilmEntity, Film>();
        CreateMap<Film, FilmEntity>();
    }
}
