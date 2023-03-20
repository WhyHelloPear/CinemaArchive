using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;
using Domain.Contracts;
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

        public async Task<List<FilmDto>> GetFilms()
        {
            var films = await _filmRepository.GetFilms();
            return _mapper.Map<List<FilmDto>>( films );
        }

        public async Task<Result> CreateFilm( FilmDto filmToCreate )
        {
            Film film = _mapper.Map<Film>( filmToCreate );

            return await _filmRepository.CreateFilm( film );
        }

        public Task<Result> UpdateFilm( FilmDto filmToUpdate )
        {
            throw new NotImplementedException();
        }

        public Task<Result> DeleteFilm( int filmId )
        {
            throw new NotImplementedException();
        }
    }
}
