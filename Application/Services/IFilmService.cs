using Core.Application.DTOs;

namespace Core.Application.Services
{
    public interface IFilmService
    {
        Task<IQueryable<FilmDto>> GetFilms();
    }
}
