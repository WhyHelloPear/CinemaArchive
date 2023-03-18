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

        public Task<List<Film>> GetFilms()
        {
            return _dbContext.FilmEntities.ProjectTo<Film>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public Task<int> GetNumFilms()
        {
            return _dbContext.FilmEntities.CountAsync();
        }

        public Task<int> GetNumGenres()
        {
            return _dbContext.GenreEntities.CountAsync();
        }

        public async Task<int> SaveFilm(Film filmEntity)
        {
            FilmEntity? existingFilm = _dbContext.FilmEntities.FirstOrDefault(f => 
                f.FilmId == filmEntity.FilmId ||
                (f.FilmTitle == filmEntity.FilmTitle && f.ReleaseDate == filmEntity.ReleaseDate)
            );

            if (existingFilm == null)
            {
                existingFilm = _mapper.Map<FilmEntity>( filmEntity);
                _dbContext.FilmEntities.Add(existingFilm);
                _dbContext.SaveChanges();
            }
            else
            {
                existingFilm.FilmTitle = filmEntity.FilmTitle;
                existingFilm.ReleaseDate = filmEntity.ReleaseDate;
            }

            return await _dbContext.SaveChangesAsync();
        }
    }
}
