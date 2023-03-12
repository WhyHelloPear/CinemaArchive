using Core.Application.DTOs;
using Domain.Contracts;

namespace Core.Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }

        Task<IQueryable<FilmDto>> IFilmService.GetFilms()
        {
            throw new NotImplementedException();
        }
    }
}
