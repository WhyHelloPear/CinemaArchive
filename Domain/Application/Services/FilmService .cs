using AutoMapper;
using Core.Domain.Contracts;
using Core.Domain.Models;
using FluentResults;

namespace Core.Application.Services
{
    public class FilmService : IFilmService
    {
        private readonly IMapper _mapper;
        private readonly IFilmRepository _filmRepository;

        public FilmService( IFilmRepository filmRepository, IMapper mapper )
        {
            _mapper = mapper;
            _filmRepository = filmRepository;
        }

        public async Task<int> GetFilmCount()
        {
            return await _filmRepository.GetNumFilms();
        }

        public async Task<List<Film>> GetFilms()
        {
            return await _filmRepository.GetFilms();
        }

        public async Task<Result> CreateFilm( Film filmToCreate )
        {
            return await _filmRepository.CreateFilm( filmToCreate );
        }

        public Task<Result> UpdateFilm( Film filmToUpdate )
        {
            return _filmRepository.UpdateFilm( filmToUpdate );
        }

        public Task<Result> DeleteFilm( int filmId )
        {
            return _filmRepository.DeleteFilm( filmId );
        }

        public async Task<Film> GetFilm( int id )
        {
            return await _filmRepository.GetFilm( id );
        }
    }
}
