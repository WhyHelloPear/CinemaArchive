﻿using AutoMapper;
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

        public FilmRepository( CinemaArchiveDbContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result> CreateFilm( Film filmToCreate )
        {
            if( _dbContext.FilmEntities.Any( film =>
                filmToCreate.FilmTitle == film.FilmTitle && filmToCreate.ReleaseDate == film.ReleaseDate
            ) ) {
                return Result.Fail( "Film already exists." );
            }

            FilmEntity newFilm = _mapper.Map<FilmEntity>( filmToCreate );
            int newFilmId = _dbContext.Add( newFilm ).Entity.FilmId;

            if(filmToCreate.GenreList.Any() ) {
                _dbContext.AddRange(
                    filmToCreate.GenreList.Select( g => new FilmGenreLinkEntity( newFilmId, g.GenreId ) )
                );
            }

            int numChanges = await _dbContext.SaveChangesAsync();

            return numChanges > 0 ? Result.Ok() : Result.Fail( "Unable to save changes" );
        }

        public async Task<Result> DeleteFilm( int filmId )
        {
            FilmEntity? targetFilm = _dbContext.FilmEntities
                .Include(f => f.FilmGenreLinks)
                .FirstOrDefault( f => f.FilmId == filmId );

            if( targetFilm == null ) {
                return Result.Fail( "Film does not exist" );
            }

            _dbContext.FilmGenreLinkEntities.RemoveRange( targetFilm.FilmGenreLinks );
            _dbContext.FilmEntities.Remove( targetFilm );

            int numChanges = await _dbContext.SaveChangesAsync();
            return numChanges > 0 ? Result.Ok() : Result.Fail( "Unable to delete film." );
        }

        public async Task<List<Film>> GetFilms()
        {
            return await _dbContext.FilmEntities
                .Include( i => i.FilmGenreLinks )
                .ThenInclude( i => i.Genre )
                .ProjectTo<Film>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }

        public Task<int> GetNumFilms()
        {
            return _dbContext.FilmEntities.CountAsync();
        }

        public async Task<Result> UpdateFilm( Film filmToCreate )
        {
            FilmEntity? targetfilm = _dbContext.FilmEntities
                .Include( f => f.FilmGenreLinks )
                .FirstOrDefault( f => f.FilmId == filmToCreate.FilmId );

            if( targetfilm == null ) {
                return Result.Fail( "Film does not exist" );
            }

            List<int> currentGenreLinks = targetfilm.FilmGenreLinks.Select( fgl => fgl.GenreId ).ToList();
            List<int> updatedGenreLinks = filmToCreate.GenreList.Select( g => g.GenreId ).ToList();

            List<int> genreLinksToAdd = updatedGenreLinks.Except( currentGenreLinks ).ToList();
            List<int> genreLinksToRemove = currentGenreLinks.Except( updatedGenreLinks ).ToList();

            if( genreLinksToAdd.Any() ) {
                _dbContext.FilmGenreLinkEntities.AddRange(
                    genreLinksToAdd.Select( genreId => new FilmGenreLinkEntity( targetfilm.FilmId, genreId ) )
                );
            }
            if( genreLinksToRemove.Any() ) {
                _dbContext.FilmGenreLinkEntities.RemoveRange(
                    targetfilm.FilmGenreLinks.Where( fgl => genreLinksToRemove.Contains( fgl.GenreId ) )
                );
            }

            targetfilm.FilmTitle = filmToCreate.FilmTitle;
            targetfilm.ReleaseDate = filmToCreate.ReleaseDate;

            int numChanges = await _dbContext.SaveChangesAsync();

            return numChanges > 0 ? Result.Ok() : Result.Fail( "No changes made." );
        }
    }
}
