using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services {
    public interface IFilmService {
        Task<List<FilmDto>> GetFilms();
        Task<Result> SaveFilm( FilmDto film );
        Task<int> GetFilmCount();
        Task<int> GetGenreCount();
        Task<object?> GetGenres();
    }
}
