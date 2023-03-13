using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Models;
using Domain.Contracts;
using FluentResults;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class FilmRepository : IFilmRepository
    {
        private readonly IMapper _mapper;
        private readonly CinemaArchiveDbContext _dbContext;

        public FilmRepository(CinemaArchiveDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Task<int> AddFilm(Film newFilm)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddGenre(Genre newGenre)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddGenreToFilm(int genreId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddPersonToFilm(int personId, int positionId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteFilm(int targetFilmId)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteGenre(int targetGenreId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Film>> GetFilms()
        {
            return _dbContext.FilmEntities.ProjectTo<Film>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<IEnumerable<Genre>> GetGenres()
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveGenreFromFilm(int genreId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemovePersonFromFilm(int personId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<int> RemovePersonFromFilm(int personId, int positionId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateFilm(Film updatedFilm)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateGenre(Genre updatedGenre)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNumFilms()
        {
            return _dbContext.FilmEntities.CountAsync();
        }

        public Task<int> GetNumGenres()
        {
            return _dbContext.GenreEntities.CountAsync();
        }
    }
}
