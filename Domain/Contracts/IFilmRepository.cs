using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IFilmRepository
    {
        //Film Methods
        Task<IEnumerable<Film>> GetFilms();
        Task<Result<int>> AddFilm(Film newFilm);
        Task<Result<int>> DeleteFilm(int targetFilmId);
        Task<Result<int>> UpdateFilm(Film updatedFilm);

        //Genre Methods
        Task<IEnumerable<Genre>> GetGenres();
        Task<Result<int>> AddGenre(Genre newGenre);
        Task<Result<int>> DeleteGenre(int targetGenreId);
        Task<Result<int>> UpdateGenre(Genre updatedGenre);

        //Linking Methods
        Task<Result<int>> AddGenreToFilm(int genreId, int filmId);
        Task<Result<int>> RemoveGenreFromFilm(int genreId, int filmId);
        Task<Result<int>> AddPersonToFilm(int personId, int positionId, int filmId);
        Task<Result<int>> RemovePersonFromFilm(int personId, int filmId);
        Task<Result<int>> RemovePersonFromFilm(int personId, int positionId, int filmId);
    }
}
