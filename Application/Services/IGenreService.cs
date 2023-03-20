using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services
{
    public interface IGenreService
    {
        Task<List<GenreDto>> GetGenres();
        Task<Result> CreateGenre( GenreDto genreToCreate );
        Task<Result> UpdateGenre( GenreDto genreToUpdate );
        Task<Result> DeleteGenre( int genreId );
        Task<int> GetGenreCount();
    }
}
