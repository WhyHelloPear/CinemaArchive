using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IGenreRepository
    {
        Task<int> GetNumGenres();
        Task<List<Genre>> GetGenres();
        Task<Result> CreateGenre( Genre genreToCreate );
        Task<Result> UpdateGenre( Genre genreToUpdate );
        Task<Result> DeleteGenre( int genreId );
    }
}
