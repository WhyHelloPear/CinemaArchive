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

        public async Task<int> GetGenreCount()
        {
            return await _filmRepository.GetNumGenres();
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            var films = await _filmRepository.GetGenres();
            return _mapper.Map<List<GenreDto>>( films );
        }

        public async Task<Result> CreateGenre( GenreDto genreToCreate )
        {
            Genre genre = _mapper.Map<Genre>( genreToCreate );
            return await _filmRepository.CreateGenre( genre );
        }

        public async Task<Result> CreateFilm( FilmDto filmToCreate )
        {
            Film film = _mapper.Map<Film>( filmToCreate );

            return await _filmRepository.CreateFilm( film );
        }

        public async Task<Result> UpdateGenre( GenreDto genreToUpdate )
        {
            Genre genre = _mapper.Map<Genre>( genreToUpdate );
            return await _filmRepository.UpdateGenre( genre );
        }

        public async Task<Result> DeleteGenre( int genreId )
        {
            return await _filmRepository.DeleteGenre( genreId );
        }
    }
}
