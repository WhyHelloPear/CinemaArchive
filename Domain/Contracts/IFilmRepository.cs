using Core.Domain.Models;

namespace Domain.Contracts {
    public interface IFilmRepository {
        Task<int> GetNumFilms();
        Task<List<Film>> GetFilms();
        Task<List<Genre>> GetGenres();
        Task<int> GetNumGenres();
        Task<int> SaveFilm( Film filmEntity );
    }
}
