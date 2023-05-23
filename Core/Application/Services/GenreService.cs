using AutoMapper;
using Core.Domain.Contracts;
using Core.Domain.Models;
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

        public async Task<List<Genre>> GetGenres()
        {
            return await _genreRepository.GetGenres();
        }

        public async Task<Result> CreateGenre( Genre genreToCreate )
        {
            return await _genreRepository.CreateGenre( genreToCreate );
        }

        public async Task<Result> UpdateGenre( Genre genreToUpdate )
        {
            return await _genreRepository.UpdateGenre( genreToUpdate );
        }

        public async Task<Result> DeleteGenre( int genreId )
        {
            return await _genreRepository.DeleteGenre( genreId );
        }
    }
}
