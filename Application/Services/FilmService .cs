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

        public Task<Result> CreateFilm( FilmDto film )
        {
            Film filmToCreate = _mapper.Map<Film>( film );
            return await _filmRepository.CreateFilm( filmToCreate );
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

        public async Task<int> GetGenreCount()
        {
            return await _filmRepository.GetNumGenres();
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            var films = await _filmRepository.GetGenres();
            return _mapper.Map<List<GenreDto>>( films );
        }

        public async Task<Result> SaveFilm( FilmDto film )
        {
            Film filmToSave = _mapper.Map<Film>( film );
            var result = await _filmRepository.SaveFilm( filmToSave );

            return result == 0 ? Result.Fail( "Unable to save film." ) : Result.Ok();
        }

        public async Task<Result> SaveGenre( GenreDto genre )
        {
            Genre genreToSave = _mapper.Map<Genre>( genre );
            var result = await _filmRepository.SaveGenre( genreToSave );

            return result == 0 ? Result.Fail( "Unable to save film." ) : Result.Ok();
        }
    }
}
