﻿using AutoMapper;
using Core.Domain.Models;
using Infrastructure.DataAccess.Entities;

public class DataAccessMappingConfig : Profile {
    public DataAccessMappingConfig() {
        CreateMap<FilmEntity, Film>();
        CreateMap<Film, FilmEntity>()
            .ForMember( vm => vm.FilmId, m => m.Ignore() );

        CreateMap<GenreEntity, Genre>();
        CreateMap<Genre, GenreEntity>()
            .ForMember( vm => vm.GenreId, m => m.Ignore() );

        CreateMap<Person, PersonEntity>();
        CreateMap<PersonEntity, Person>();

        CreateMap<FilmRole, FilmRoleEntity>();
        CreateMap<FilmRoleEntity, FilmRole>();

        CreateMap<FilmGenreLink, FilmGenreLinkEntity>();
        CreateMap<FilmGenreLinkEntity, FilmGenreLink>();

        CreateMap<FilmPersonLink, FilmPersonLinkEntity>();
        CreateMap<FilmPersonLinkEntity, FilmPersonLink>();
    }
}
