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

        public async Task<List<FilmDto>> GetFilms()
        {
            var films = await _filmRepository.GetFilms();
            return _mapper.Map<List<FilmDto>>(films);
        }
    }
}
