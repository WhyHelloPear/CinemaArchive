using AutoMapper;
using Core.Application.DTOs;
using Domain.Contracts;

namespace Core.Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository, IMapper mapper)
        {
            _mapper = mapper;
            _filmRepository = filmRepository;
        }

        public async Task<IEnumerable<FilmDto>> GetFilms()
        {

            return Enumerable.Empty<FilmDto>();
        }
    }
}
