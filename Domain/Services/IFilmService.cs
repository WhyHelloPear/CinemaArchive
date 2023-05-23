using Core.Domain.Models;
using FluentResults;

namespace Core.Domain.Services
{
    public interface IFilmService
    {
        Task<List<Film>> GetFilms();
        Task<Result> CreateFilm( Film filmToCreate );
        Task<Result> UpdateFilm( Film filmToUpdate );
        Task<Result> DeleteFilm( int filmId );
        Task<int> GetFilmCount();
        Task<Film> GetFilm( int id );
    }
}
