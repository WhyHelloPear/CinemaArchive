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
        Task<int> SaveFilm( Film filmToSave );
        Task<int> SaveGenre( Genre genreToSave );

        Task<int> CreateFilm( Film filmToCreate );
        Task<int> CreateGenre( Genre genreToCreate );
    }
}
