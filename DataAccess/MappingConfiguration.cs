using AutoMapper;
using Core.Domain.Models;
using Infrastructure.DataAccess.Entities;

public class DataAccessMappingConfig : Profile
{
    public DataAccessMappingConfig()
    {
        CreateMap<FilmEntity, Film>()
            .ForMember( f => f.GenreList, m => m.MapFrom( fe => fe.FilmGenreLinks.Select( fgl => fgl.Genre ) ) );

        CreateMap<Film, FilmEntity>()
            .ForMember( vm => vm.FilmId, m => m.Ignore() );

        CreateMap<GenreEntity, Genre>();
        CreateMap<Genre, GenreEntity>()
            .ForMember( vm => vm.GenreId, m => m.Ignore() );

        CreateMap<PersonEntity, Person>();
        CreateMap<Person, PersonEntity>()
            .ForMember( vm => vm.PersonId, m => m.Ignore() );

        CreateMap<FilmRole, FilmRoleEntity>();
        CreateMap<FilmRoleEntity, FilmRole>();

        CreateMap<FilmGenreLink, FilmGenreLinkEntity>();
        CreateMap<FilmGenreLinkEntity, FilmGenreLink>();

        CreateMap<FilmPersonLink, FilmPersonLinkEntity>();
        CreateMap<FilmPersonLinkEntity, FilmPersonLink>();
    }
}
