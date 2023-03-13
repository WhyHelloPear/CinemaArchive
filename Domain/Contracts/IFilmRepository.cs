using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IFilmRepository
    {
        //Film Methods
        Task<int> GetNumFilms();
        Task<List<Film>> GetFilms();
        Task<int> AddFilm(Film newFilm);
        Task<int> DeleteFilm(int targetFilmId);
        Task<int> UpdateFilm(Film updatedFilm);

        //Genre Methods
        Task<int> GetNumGenres();
        Task<IEnumerable<Genre>> GetGenres();
        Task<int> AddGenre(Genre newGenre);
        Task<int> DeleteGenre(int targetGenreId);
        Task<int> UpdateGenre(Genre updatedGenre);

        //Linking Methods
        Task<int> AddGenreToFilm(int genreId, int filmId);
        Task<int> RemoveGenreFromFilm(int genreId, int filmId);
        Task<int> AddPersonToFilm(int personId, int positionId, int filmId);
        Task<int> RemovePersonFromFilm(int personId, int filmId);
        Task<int> RemovePersonFromFilm(int personId, int positionId, int filmId);
    }
}
