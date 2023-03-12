using Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IFilmRepository
    {
        //Film Methods
        IQueryable<Film> GetFilms();
        Result<int> AddFilm(Film newFilm);
        Result<int> DeleteFilm(int targetFilmId);
        Result<int> UpdateFilm(Film updatedFilm);
        
        //Genre Methods
        IQueryable<Genre> GetGenres();
        Result<int> AddGenre(Genre newGenre);
        Result<int> DeleteGenre(int targetGenreId);
        Result<int> UpdateGenre(Genre updatedGenre);

        //Linking Methods
        Result<int> AddGenreToFilm(int genreId, int filmId);
        Result<int> RemoveGenreFromFilm(int genreId, int filmId);
        Result<int> AddPersonToFilm(int personId, int positionId,  int filmId);
        Result<int> RemovePersonFromFilm(int personId,  int filmId);
        Result<int> RemovePersonFromFilm(int personId, int positionId,  int filmId);
    }
}
