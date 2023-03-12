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

        public Task<Result<int>> AddFilm(Film newFilm)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> AddGenre(Genre newGenre)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> AddGenreToFilm(int genreId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> AddPersonToFilm(int personId, int positionId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> DeleteFilm(int targetFilmId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> DeleteGenre(int targetGenreId)
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

        public Task<Result<int>> RemoveGenreFromFilm(int genreId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> RemovePersonFromFilm(int personId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> RemovePersonFromFilm(int personId, int positionId, int filmId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> UpdateFilm(Film updatedFilm)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> UpdateGenre(Genre updatedGenre)
        {
            throw new NotImplementedException();
        }
    }
}
