﻿using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services
{
    public interface IFilmService
    {
        Task<List<FilmDto>> GetFilms();
        Task<List<GenreDto>> GetGenres();
        Task<Result> CreateFilm( FilmDto film );
        Task<Result> SaveFilm( FilmDto film );
        Task<Result> SaveGenre( GenreDto film );
        Task<int> GetFilmCount();
        Task<int> GetGenreCount();
    }
}
