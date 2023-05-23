using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Contracts;
using Core.Domain.Models;
using FluentResults;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IMapper _mapper;
        private readonly CinemaArchiveDbContext _dbContext;

        public GenreRepository( CinemaArchiveDbContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result> CreateGenre( Genre genreToCreate )
        {
            if( _dbContext.GenreEntities.Any( genre => string.Equals( genre.GenreName.ToLower().Trim(), genreToCreate.GenreName.ToLower().Trim() ) ) ) {
                return Result.Fail( "Genre already exists." );
            }

            GenreEntity newFilm = _mapper.Map<GenreEntity>( genreToCreate );
            _dbContext.Add( newFilm );

            int numChanges = await _dbContext.SaveChangesAsync();

            return numChanges > 0 ? Result.Ok() : Result.Fail( "Unable to save changes" );
        }

        public async Task<Result> DeleteGenre( int genreId )
        {
            GenreEntity? targetGenre = _dbContext.GenreEntities.FirstOrDefault( g => g.GenreId == genreId );

            if( targetGenre == null ) {
                return Result.Fail( "Unable to find genre to delete." );
            }

            _dbContext.GenreEntities.Remove( targetGenre );
            int changesMade = await _dbContext.SaveChangesAsync();

            return changesMade > 0 ? Result.Ok() : Result.Fail( "Unable to delete genre." );
        }

        public async Task<List<Genre>> GetGenres()
        {
            return await _dbContext.GenreEntities
                .ProjectTo<Genre>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }

        public Task<int> GetNumGenres()
        {
            return _dbContext.GenreEntities.CountAsync();
        }

        public async Task<Result> UpdateGenre( Genre genreToUpdate )
        {
            GenreEntity? existingGenre = _dbContext.GenreEntities.FirstOrDefault( g => g.GenreId == genreToUpdate.GenreId );

            if( existingGenre == null ) {
                return Result.Fail( "Unable to find existing genre with matching id." );
            }

            if( _dbContext.GenreEntities.Any( g => g.GenreName == genreToUpdate.GenreName ) ) {
                return Result.Fail( "Genre with name already exists." );
            }

            existingGenre.GenreName = genreToUpdate.GenreName;

            int numUpdates = await _dbContext.SaveChangesAsync();

            return numUpdates > 0 ? Result.Ok() : Result.Fail( "Unable to update genre" );
        }
    }
}
