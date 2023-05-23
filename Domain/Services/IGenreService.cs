using Core.Domain.Models;
using FluentResults;

namespace Core.Domain.Services
{
    public interface IGenreService
    {
        Task<List<Genre>> GetGenres();
        Task<Result> CreateGenre( Genre genreToCreate );
        Task<Result> UpdateGenre( Genre genreToUpdate );
        Task<Result> DeleteGenre( int genreId );
        Task<int> GetGenreCount();
    }
}
