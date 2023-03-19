using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IFilmRepository
    {
        Task<int> GetNumFilms();
        Task<List<Film>> GetFilms();
        Task<List<Genre>> GetGenres();
        Task<int> GetNumGenres();
        Task<Result> CreateFilm( Film filmToCreate );
        Task<Result> CreateGenre( Genre genreToCreate );
        Task<Result> UpdateGenre( Genre genreToUpdate );
        Task<Result> DeleteGenre( int genreId );
    }
}
