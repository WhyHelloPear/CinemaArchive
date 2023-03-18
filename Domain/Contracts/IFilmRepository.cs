using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IFilmRepository
    {
        Task<int> GetNumFilms();
        Task<List<Film>> GetFilms();
        Task<int> GetNumGenres();
        Task<int> SaveFilm(Film filmEntity);
    }
}
