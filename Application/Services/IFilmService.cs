using Core.Application.DTOs;

namespace Core.Application.Services
{
    public interface IFilmService
    {
        Task<IEnumerable<FilmDto>> GetFilms();
    }
}
