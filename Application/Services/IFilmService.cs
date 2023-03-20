using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services
{
    public interface IFilmService
    {
        Task<List<FilmDto>> GetFilms();
        Task<Result> CreateFilm( FilmDto filmToCreate );
        Task<Result> UpdateFilm( FilmDto filmToUpdate );
        Task<Result> DeleteFilm( int filmId );
        Task<int> GetFilmCount();
    }
}
