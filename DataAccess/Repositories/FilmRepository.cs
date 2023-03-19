using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Models;
using Domain.Contracts;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories {
    public class FilmRepository : IFilmRepository {
        private readonly IMapper _mapper;
        private readonly CinemaArchiveDbContext _dbContext;

        public FilmRepository( CinemaArchiveDbContext dbContext, IMapper mapper ) {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Film>> GetFilms() {
            return await _dbContext.FilmEntities
                .ProjectTo<Film>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }

        public async Task<List<Genre>> GetGenres() {
            return await _dbContext.GenreEntities
                .ProjectTo<Genre>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }

        public Task<int> GetNumFilms() {
            return _dbContext.FilmEntities.CountAsync();
        }

        public Task<int> GetNumGenres() {
            return _dbContext.GenreEntities.CountAsync();
        }

        public async Task<int> SaveFilm( Film filmToSave ) {
            FilmEntity? existingFilm = _dbContext.FilmEntities.FirstOrDefault( f =>
                f.FilmId == filmToSave.FilmId ||
                ( f.FilmTitle == filmToSave.FilmTitle && f.ReleaseDate == filmToSave.ReleaseDate )
            );

            if( existingFilm == null ) {
                existingFilm = _mapper.Map<FilmEntity>( filmToSave );
                _dbContext.FilmEntities.Add( existingFilm );
            }
            else {
                existingFilm.FilmTitle = filmToSave.FilmTitle;
                existingFilm.ReleaseDate = filmToSave.ReleaseDate;
            }

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveGenre( Genre genreToSave ) {
            GenreEntity? existingGenre = _dbContext.GenreEntities.FirstOrDefault( f =>
                f.GenreId == genreToSave.GenreId || f.GenreName == genreToSave.GenreName
            );

            if( existingGenre == null ) {
                existingGenre = _mapper.Map<GenreEntity>( genreToSave );
                _dbContext.GenreEntities.Add( existingGenre );
            }
            else {
                existingGenre.GenreName = genreToSave.GenreName;
            }

            return await _dbContext.SaveChangesAsync();
        }
    }
}
