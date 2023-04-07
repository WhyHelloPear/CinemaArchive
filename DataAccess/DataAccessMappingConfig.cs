using AutoMapper;
using Core.Domain.Models;
using Infrastructure.DataAccess.Entities;

public class DataAccessMappingConfig : Profile
{
    public DataAccessMappingConfig()
    {
        CreateMap<FilmEntity, Film>()
            .ForMember( f => f.GenreList, m => m.MapFrom( fe => fe.FilmGenreLinks.Select( fgl => fgl.Genre ) ) )
            .ForMember( f => f.FilmPersonLinks, m => m.MapFrom( fe => fe.FilmPersonLinks ) );

        CreateMap<Film, FilmEntity>()
            .ForMember( vm => vm.FilmId, m => m.Ignore() )
            .ForMember( f => f.FilmPersonLinks, m => m.MapFrom( fe => fe.FilmPersonLinks ) );

        CreateMap<GenreEntity, Genre>();
        CreateMap<Genre, GenreEntity>()
            .ForMember( vm => vm.GenreId, m => m.Ignore() );

        CreateMap<PersonEntity, Person>();
        CreateMap<Person, PersonEntity>()
            .ForMember( vm => vm.PersonId, m => m.Ignore() );

        CreateMap<FilmRoleEntity, FilmRole>();
        CreateMap<FilmRole, FilmRoleEntity>()
            .ForMember( vm => vm.FilmRoleId, m => m.Ignore() );

        CreateMap<FilmPersonLink, FilmPersonLinkEntity>()
            .ForMember( f => f.Film, m => m.MapFrom( fe => fe.RelatedFilm ) )
            .ForMember( f => f.Person, m => m.MapFrom( fe => fe.RelatedPerson ) )
            .ForMember( f => f.FilmRole, m => m.MapFrom( fe => fe.RelatedFilmRole ) );

        CreateMap<FilmPersonLinkEntity, FilmPersonLink>()
            .ForMember( f => f.RelatedFilm, m => m.MapFrom( fe => fe.Film ) )
            .ForMember( f => f.RelatedPerson, m => m.MapFrom( fe => fe.Person ) )
            .ForMember( f => f.RelatedFilmRole, m => m.MapFrom( fe => fe.FilmRole ) );
    }
}
