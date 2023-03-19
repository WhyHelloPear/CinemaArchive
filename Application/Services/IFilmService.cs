using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services
{
    public interface IFilmService
    {
        Task<List<FilmDto>> GetFilms();
        Task<List<GenreDto>> GetGenres();
        Task<Result> CreateFilm( FilmDto filmToCreate );
        Task<Result> CreateGenre( GenreDto genreToCreate );
        Task<Result> UpdateGenre( GenreDto genreToUpdate );
        Task<Result> DeleteGenre( int genreId );
        Task<int> GetFilmCount();
        Task<int> GetGenreCount();
    }
}
