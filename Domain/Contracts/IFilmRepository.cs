using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IFilmRepository
    {
        Task<int> GetNumFilms();
        Task<List<Film>> GetFilms();
        Task<Result> CreateFilm( Film filmToCreate );
        Task<Result> UpdateFilm( Film filmToCreate );
        Task<Result> DeleteFilm( int filmId );
    }
}
