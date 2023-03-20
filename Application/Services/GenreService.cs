using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;
using Domain.Contracts;
using FluentResults;

namespace Core.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public GenreService( IGenreRepository genreRepository, IMapper mapper )
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        public async Task<int> GetGenreCount()
        {
            return await _genreRepository.GetNumGenres();
        }

        public async Task<List<GenreDto>> GetGenres()
        {
            var films = await _genreRepository.GetGenres();
            return _mapper.Map<List<GenreDto>>( films );
        }

        public async Task<Result> CreateGenre( GenreDto genreToCreate )
        {
            Genre genre = _mapper.Map<Genre>( genreToCreate );
            return await _genreRepository.CreateGenre( genre );
        }

        public async Task<Result> UpdateGenre( GenreDto genreToUpdate )
        {
            Genre genre = _mapper.Map<Genre>( genreToUpdate );
            return await _genreRepository.UpdateGenre( genre );
        }

        public async Task<Result> DeleteGenre( int genreId )
        {
            return await _genreRepository.DeleteGenre( genreId );
        }
    }
}
